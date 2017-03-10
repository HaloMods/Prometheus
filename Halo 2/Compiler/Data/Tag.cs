using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Games.Halo2.Compiler.Classes;
using Games.Halo2.Platforms.Shared;
using Games.Halo2.Tags;
using Interfaces;
using Interfaces.Policies;

namespace Games.Halo2.Compiler.Data
{
  public class Tag
  {
    private const int Signature = 0x74616720; // 'tag '
    private const int BitmapLevelCount = 6;

    private const int Sound = 0x736e6421; // 'snd!'
    private const int StringList = 0x756e6963; // 'unic'

    private TagHeader header;
    private MemoryStream tagData;
    private MemoryStream extraData;

    private static readonly Halo2TypeTable typeTable = new Halo2TypeTable();

    [StructLayout(LayoutKind.Sequential)]
    private struct TagHeader
    {
      public int Signature;
      public int Type;
      public int TagDataSize;
      public int ExtraDataSize;
    }

    public Tag(int type)
    {
      header = new TagHeader();
      header.Signature = Signature;
      header.Type = type;
      tagData = new MemoryStream();
      extraData = new MemoryStream();
    }

    public Tag(BinaryReader reader)
    {
      header = Reinterpret.Memory<TagHeader>(reader.ReadBytes(Marshal.SizeOf(typeof(TagHeader))));
      if (header.Signature != Signature)
        throw new InvalidDataException("Invalid tag signature.");
      tagData = new MemoryStream(reader.ReadBytes(header.TagDataSize), false);
      extraData = new MemoryStream(reader.ReadBytes(header.ExtraDataSize), false);
    }

    public void ReadData(BinaryReader reader, SharedMaps maps, int magic, IDictionary<int, string> tags, string[] strings, Coconuts coconuts, Globals globals, string debugName)
    {
      BinaryWriter writer = new BinaryWriter(tagData);
      Class definition = Singleton<ClassManager>.Instance.GetClassByID(header.Type);

      // read tag data
      long position = reader.BaseStream.Position;
      writer.Write(reader.ReadBytes(definition.RootBlockSize));
      RecursiveReadData(definition.Elements, definition.RootElementIndex, reader, writer, new BinaryWriter(extraData), maps, magic, tags, strings, coconuts, globals, (int)(reader.BaseStream.Position - definition.RootBlockSize), 0, debugName);

      // read extra data
      switch (header.Type)
      {
        #region sound
        case Sound:
          reader.BaseStream.Position = position;
          CacheFileSound sound = Reinterpret.Memory<CacheFileSound>(reader.ReadBytes(Marshal.SizeOf(typeof(CacheFileSound))));
          Coconuts individual = new Coconuts();
          MemoryStream soundRaw = new MemoryStream();

          if (sound.PlaybackIndex >= 0)
          {
            individual.PlaybackParameters.Add(coconuts.PlaybackParameters[sound.PlaybackIndex]);
            sound.PlaybackIndex = (short)(individual.PlaybackParameters.Count - 1);
          }

          if (sound.ScaleIndex >= 0)
          {
            individual.Scales.Add(coconuts.Scales[sound.ScaleIndex]);
            sound.ScaleIndex = (sbyte)(individual.Scales.Count - 1);
          }

          if (sound.CustomPlaybackIndex >= 0)
          {
            Coconuts.CustomPlayback customPlayback = coconuts.CustomPlaybacks[sound.CustomPlaybackIndex];

            List<Coconuts.CustomPlayback.Filter> filters = new List<Coconuts.CustomPlayback.Filter>(customPlayback.FilterCount);
            for (int i = 0; i < customPlayback.FilterCount; i++)
              filters.Add(coconuts.CustomFilters[sound.CustomPlaybackIndex][i]);
            individual.CustomFilters.Add(filters);

            List<Coconuts.CustomPlayback.PitchPlaybackParameters> playbackParameters = new List<Coconuts.CustomPlayback.PitchPlaybackParameters>(customPlayback.PitchPlaybackParametersCount);
            for (int i = 0; i < customPlayback.PitchPlaybackParametersCount; i++)
              playbackParameters.Add(coconuts.CustomPitchParameters[sound.CustomPlaybackIndex][i]);
            individual.CustomPitchParameters.Add(playbackParameters);

            individual.CustomPlaybacks.Add(coconuts.CustomPlaybacks[sound.CustomPlaybackIndex]);
            sound.CustomPlaybackIndex = (sbyte)(individual.CustomPlaybacks.Count - 1);
          }

          if (sound.PromotionIndex >= 0)
          {
            Coconuts.Promotion promotion = coconuts.Promotions[sound.PromotionIndex];

            List<Coconuts.Promotion.Rule> rules = new List<Coconuts.Promotion.Rule>(promotion.RuleCount);
            for (int i = 0; i < promotion.RuleCount; i++)
              rules.Add(coconuts.PromotionRules[sound.PromotionIndex][i]);
            individual.PromotionRules.Add(rules);

            List<Coconuts.Promotion.Timer> timers = new List<Coconuts.Promotion.Timer>(promotion.TimerCount);
            for (int i = 0; i < promotion.TimerCount; i++)
              timers.Add(coconuts.PromotionTimers[sound.PromotionIndex][i]);
            individual.PromotionTimers.Add(timers);

            individual.Promotions.Add(coconuts.Promotions[sound.PromotionIndex]);
            sound.PromotionIndex = (sbyte)(individual.Promotions.Count - 1);
          }

          if (sound.ExtraInfoIndex >= 0)
          {
            Coconuts.ExtraInfo extraInfo = coconuts.ExtraInfos[sound.ExtraInfoIndex];
            individual.ExtraInfoData.Add(coconuts.ExtraInfoData[sound.ExtraInfoIndex]);

            List<ResourceBlock.Resource> resources = new List<ResourceBlock.Resource>(extraInfo.ResourceBlock.ResourceCount);
            for (int i = 0; i < extraInfo.ResourceBlock.ResourceCount; i++)
              resources.Add(coconuts.ExtraInfoResources[sound.ExtraInfoIndex][i]);
            individual.ExtraInfoResources.Add(resources);

            individual.ExtraInfos.Add(coconuts.ExtraInfos[sound.ExtraInfoIndex]);
            sound.ExtraInfoIndex = (short)(individual.ExtraInfos.Count - 1);
          }

          if (sound.PitchRangeIndex >= 0)
          {
            int pitchRangeIndex = individual.PitchRanges.Count;
            for (byte i = 0; i < sound.PitchRangeCount; i++)
            {
              Coconuts.PitchRange pitchRange = coconuts.PitchRanges[sound.PitchRangeIndex + i];

              if (pitchRange.ParametersBlockIndex >= 0)
              {
                individual.PitchRangeParameters.Add(coconuts.PitchRangeParameters[pitchRange.ParametersBlockIndex]);
                pitchRange.ParametersBlockIndex = (short)(individual.PitchRangeParameters.Count - 1);
              }

              if (pitchRange.NameBlockIndex >= 0)
              {
                individual.ImportNames.Add(coconuts.ImportNames[pitchRange.NameBlockIndex]);
                pitchRange.NameBlockIndex = (short)(individual.ImportNames.Count - 1);
              }

              if (pitchRange.FirstPermutationIndex >= 0)
              {
                int firstPermutationIndex = individual.Permutations.Count;
                for (short j = 0; j < pitchRange.PermutationCount; j++)
                {
                  Coconuts.Permutation permutation = coconuts.Permutations[pitchRange.FirstPermutationIndex + j];

                  if (permutation.NameBlockIndex >= 0)
                  {
                    individual.ImportNames.Add(coconuts.ImportNames[permutation.NameBlockIndex]);
                    permutation.NameBlockIndex = (short)(individual.ImportNames.Count - 1);
                  }

                  if (permutation.FirstChunkIndex >= 0)
                  {
                    int firstChunkIndex = individual.Chunks.Count;
                    for (short k = 0; k < permutation.ChunkCount; k++)
                    {
                      Coconuts.Chunk chunk = coconuts.Chunks[permutation.FirstChunkIndex + k];

                      int chunkOffset = (int)soundRaw.Length;
                      BinaryReader rawReader = maps.GetMap(chunk.Offset, reader);
                      if (rawReader != null)
                        soundRaw.Write(rawReader.ReadBytes(chunk.Size), 0, chunk.Size);

                      chunk.Offset = Conversion.ToInt((Conversion.ToUInt(chunk.Offset) & 0xc0000000) | (Conversion.ToUInt(chunkOffset) & 0x3fffffff));
                      individual.Chunks.Add(chunk);
                    }
                    permutation.FirstChunkIndex = (short)firstChunkIndex;
                  }
                  individual.Permutations.Add(permutation);
                }
                pitchRange.FirstPermutationIndex = (short)firstPermutationIndex;
              }
              individual.PitchRanges.Add(pitchRange);
            }
            sound.PitchRangeIndex = (short)pitchRangeIndex;
          }

          tagData.Position = 0;
          tagData.Write(Reinterpret.Object<CacheFileSound>(sound), 0, Marshal.SizeOf(typeof(CacheFileSound)));

          individual.WriteToDataStream(new BinaryWriter(extraData));
          extraData.Write(soundRaw.ToArray(), 0, (int)soundRaw.Length);
          break;
#endregion

        #region unicode string list
        case StringList:
          reader.BaseStream.Position = position;
          UnicodeStringList stringList = Reinterpret.Memory<UnicodeStringList>(reader.ReadBytes(Marshal.SizeOf(typeof(UnicodeStringList))));

          for (short i = 0; i < stringList.Language0.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[0] + (stringList.Language0.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language0.Index + i + 1 == globals.Counts[0])
              stringLength = globals.TableSizes[0] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[0];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }

          for (short i = 0; i < stringList.Language1.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[1] + (stringList.Language1.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language1.Index + i + 1 == globals.Counts[1])
              stringLength = globals.TableSizes[1] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[1];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }

          for (short i = 0; i < stringList.Language2.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[2] + (stringList.Language2.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language2.Index + i + 1 == globals.Counts[2])
              stringLength = globals.TableSizes[2] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[2];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }

          for (short i = 0; i < stringList.Language3.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[3] + (stringList.Language3.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language3.Index + i + 1 == globals.Counts[3])
              stringLength = globals.TableSizes[3] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[3];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }

          for (short i = 0; i < stringList.Language4.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[4] + (stringList.Language4.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language4.Index + i + 1 == globals.Counts[4])
              stringLength = globals.TableSizes[4] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[4];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }

          for (short i = 0; i < stringList.Language5.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[5] + (stringList.Language5.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language5.Index + i + 1 == globals.Counts[5])
              stringLength = globals.TableSizes[5] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[5];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }

          for (short i = 0; i < stringList.Language6.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[6] + (stringList.Language6.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language6.Index + i + 1 == globals.Counts[6])
              stringLength = globals.TableSizes[6] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[6];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }

          for (short i = 0; i < stringList.Language7.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[7] + (stringList.Language7.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language7.Index + i + 1 == globals.Counts[7])
              stringLength = globals.TableSizes[7] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[7];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }

          for (short i = 0; i < stringList.Language8.Count; i++)
          {
            reader.BaseStream.Position = globals.IndexOffsets[8] + (stringList.Language8.Index + i) * 8 + 4;
            int stringLocation = reader.ReadInt32();
            int stringLength;

            if (stringList.Language8.Index + i + 1 == globals.Counts[8])
              stringLength = globals.TableSizes[8] - stringLocation;
            else
            {
              reader.BaseStream.Position += 4;
              stringLength = reader.ReadInt32() - stringLocation;
            }
            stringLocation += globals.TableOffsets[8];

            reader.BaseStream.Position = stringLocation;
            extraData.Write(BitConverter.GetBytes(stringLength), 0, sizeof(int));
            extraData.Write(reader.ReadBytes(stringLength), 0, stringLength);
          }
          break;
        #endregion
      }
    }

    private void RecursiveReadData(Element[] elements, int elementIndex, BinaryReader reader, BinaryWriter writer, BinaryWriter extraWriter, SharedMaps maps, int magic, IDictionary<int, string> tags, string[] strings, Coconuts coconuts, Globals globals, int blockOffsetInMap, int blockOffsetInMeta, string debugName)
    {
      if (elementIndex < 0)
        return;

      Element element = elements[elementIndex];
      reader.BaseStream.Position = blockOffsetInMap + element.Offset;

      int count;
      int offset;
      uint encoded = 0;
      BinaryReader rawReader;

      switch (element.Type)
      {
        #region block
        case ElementType.Block:
          count = reader.ReadInt32();
          offset = unchecked(reader.ReadInt32() - magic);

          if (count > 0 && offset > 0 && offset < reader.BaseStream.Length)
          {
            int metaBaseOffset = (int)writer.BaseStream.Position;

            writer.BaseStream.Position = blockOffsetInMeta + element.Offset + 4;
            writer.Write((int)writer.BaseStream.Length);
            writer.BaseStream.Position = writer.BaseStream.Length;

            reader.BaseStream.Position = offset;
            writer.Write(reader.ReadBytes(element.Size * count));

            for (int i = 0; i < count; i++)
              RecursiveReadData(elements, element.FirstChild, reader, writer, extraWriter, maps, magic, tags, strings, coconuts, globals, offset + i * element.Size, metaBaseOffset + i * element.Size, debugName);
          }
          else if (count > 0)
          {
            writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
            writer.Write(0);
            writer.Write(0);
            writer.BaseStream.Position = writer.BaseStream.Length;
          }
          break;
        #endregion
        #region string id
        case ElementType.StringID:
          short index = reader.ReadInt16();
          reader.BaseStream.Position++;
          byte length = reader.ReadByte();

          if (index >= 0 && index < strings.Length && strings[index].Length == length)
          {
            encoded |= (uint)writer.BaseStream.Length & 0x00ffffff;
            encoded |= (uint)((length << 24) & 0xff000000);

            writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
            writer.Write(encoded);
            writer.BaseStream.Position = writer.BaseStream.Length;

            writer.Write(Encoding.ASCII.GetBytes(strings[index]));
          }
          else if (index == -1)
          {
            // do nothing
          }
          else
          {
            writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
            writer.Write(0);
            writer.BaseStream.Position = writer.BaseStream.Length;
          }
          break;
        #endregion
        #region tag reference
        case ElementType.TagReference:
          int id = reader.ReadInt32();
          byte[] name = new byte[0];

          if (id != -1)
          {
            if (tags.ContainsKey(id))
            {
              string fileWithoutExtension = tags[id];
              fileWithoutExtension = fileWithoutExtension.Remove(fileWithoutExtension.LastIndexOf('.'));
              name = Encoding.ASCII.GetBytes(fileWithoutExtension);

              writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
              encoded |= (uint)writer.BaseStream.Length & 0x00ffffff;
              encoded |= (uint)((checked((byte)name.Length) << 24) & 0xff000000);
              writer.Write(encoded);

              writer.BaseStream.Position = writer.BaseStream.Length;
              writer.Write(name);
              writer.Write((byte)0);
            }
            else
            {
              writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
              writer.Write(-1);
              writer.BaseStream.Position = writer.BaseStream.Length;
            }
          }
          break;
        #endregion
        #region self reference
        case ElementType.SelfReference:
          int myId = reader.ReadInt32();

          writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
          if (myId == 0)
            writer.Write(0);
          else if (myId == -1)
            writer.Write(-1);
          else
            writer.Write(1);
          break;
        #endregion
        #region predicted resource
        case ElementType.PredictedResource:
          int pr = reader.ReadInt32();
          byte[] predictedResource = new byte[0];

          if (pr != -1)
          {
            if (tags.ContainsKey(pr))
            {
              predictedResource = Encoding.ASCII.GetBytes(tags[pr]);

              writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
              encoded |= (uint)writer.BaseStream.Length & 0x00ffffff;
              encoded |= (uint)((checked((byte)predictedResource.Length) << 24) & 0xff000000);
              writer.Write(encoded);

              writer.BaseStream.Position = writer.BaseStream.Length;
              writer.Write(predictedResource);
              writer.Write((byte)0);
            }
            else
            {
              writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
              writer.Write(-1);
              writer.BaseStream.Position = writer.BaseStream.Length;
            }
          }
          break;
        #endregion
        #region tag data
        case ElementType.TagData:
          count = reader.ReadInt32();
          offset = unchecked(reader.ReadInt32() - magic);

          if (count > 0 && offset > 0 && offset < reader.BaseStream.Length)
          {
            writer.BaseStream.Position = blockOffsetInMeta + element.Offset + 4;
            writer.Write((int)writer.BaseStream.Length);
            writer.BaseStream.Position = writer.BaseStream.Length;

            reader.BaseStream.Position = offset;
            writer.Write(reader.ReadBytes(count));
          }
          else if (count > 0)
          {
            writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
            writer.Write(0);
            writer.Write(0);
            writer.BaseStream.Position = writer.BaseStream.Length;
          }
          break;
        #endregion
        #region resource block
        case ElementType.ResourceBlock:
          offset = reader.ReadInt32();
          count = reader.ReadInt32();

          if ((Conversion.ToUInt(offset) & 0xc0000000) != 0)
            extraWriter.Write(offset);

          writer.BaseStream.Position = blockOffsetInMeta + element.Offset;
          writer.Write((uint)(((uint)writer.BaseStream.Length & 0x3fffffff) | (Conversion.ToUInt(offset) & 0xc0000000)));
          writer.BaseStream.Position = writer.BaseStream.Length;

          rawReader = maps.GetMap(offset, reader);
          if (rawReader != null)
            writer.Write(rawReader.ReadBytes(count));
          break;

        case ElementType.ResourceBlockInverted:
          count = reader.ReadInt32();
          offset = reader.ReadInt32();

          if ((Conversion.ToUInt(offset) & 0xc0000000) != 0)
            extraWriter.Write(offset);

          writer.BaseStream.Position = blockOffsetInMeta + element.Offset + 4;
          writer.Write((uint)(((uint)writer.BaseStream.Length & 0x3fffffff) | (Conversion.ToUInt(offset) & 0xc0000000)));
          writer.BaseStream.Position = writer.BaseStream.Length;

          rawReader = maps.GetMap(offset, reader);
          if (rawReader != null)
            writer.Write(rawReader.ReadBytes(count));
          break;
        #endregion
        #region bitmap data
        case ElementType.BitmapData:
          int[] offsets = new int[BitmapLevelCount];
          int[] counts = new int[BitmapLevelCount];

          for (int i = 0; i < BitmapLevelCount; i++)
            offsets[i] = reader.ReadInt32();
          for (int i = 0; i < BitmapLevelCount; i++)
            counts[i] = reader.ReadInt32();

          for (int i = 0; i < BitmapLevelCount; i++)
          {
            if (offsets[i] == -1)
              continue;

            if ((Conversion.ToUInt(offsets[i]) & 0xc0000000) != 0)
              extraWriter.Write(offsets[i]);

            writer.BaseStream.Position = blockOffsetInMeta + element.Offset + sizeof(int) * i;
            writer.Write((uint)(((uint)writer.BaseStream.Length & 0x3fffffff) | (Conversion.ToUInt(offsets[i]) & 0xc0000000)));
            writer.BaseStream.Position = writer.BaseStream.Length;

            rawReader = maps.GetMap(offsets[i], reader);
            if (rawReader != null)
              writer.Write(rawReader.ReadBytes(counts[i]));
          }
          break;
        #endregion

        default:
          throw new Exception("Invalid element type or corrupt class file.");
      }

      RecursiveReadData(elements, element.NextSibling, reader, writer, extraWriter, maps, magic, tags, strings, coconuts, globals, blockOffsetInMap, blockOffsetInMeta, debugName);
    }

    public byte[] GetBytes()
    {
      Flush();

      int sizeOfTagHeader = Marshal.SizeOf(typeof(TagHeader));
      byte[] output = new byte[sizeOfTagHeader + header.TagDataSize + header.ExtraDataSize];

      Array.Copy(Reinterpret.Object<TagHeader>(header), 0, output, 0, sizeOfTagHeader);
      if (header.TagDataSize > 0)
        Array.Copy(tagData.ToArray(), 0, output, sizeOfTagHeader, header.TagDataSize);
      if (header.ExtraDataSize > 0)
        Array.Copy(extraData.ToArray(), 0, output, sizeOfTagHeader + header.TagDataSize, header.ExtraDataSize);

      return output;
    }

    public byte[] GetTagData()
    {
      return tagData.ToArray();
    }

    public byte[] GetExtraData()
    {
      return extraData.ToArray();
    }

    public void WriteData(BinaryWriter writer, IList<string> strings, IDictionary<string, int> tags, Stream rawBuffer, int rawOffset, int magic, int myIdentifier)
    {
      tagData.Position = 0;
      extraData.Position = 0;

      BinaryReader reader = new BinaryReader(tagData);
      Class definition = Singleton<ClassManager>.Instance.GetClassByID(header.Type);

      writer.Write(reader.ReadBytes(definition.RootBlockSize));
      RecursiveWriteData(reader, writer, new BinaryReader(extraData), definition.Elements, definition.RootElementIndex, strings, tags, rawBuffer, rawOffset, magic, (int)(writer.BaseStream.Position - definition.RootBlockSize), 0, myIdentifier);
    }

    private void RecursiveWriteData(BinaryReader reader, BinaryWriter writer, BinaryReader extraReader, Element[] elements, int elementIndex, IList<string> strings, IDictionary<string, int> tags, Stream rawBuffer, int rawOffset, int magic, int blockOffsetInMap, int blockOffsetInMeta, int myIdentifier)
    {
      if (elementIndex < 0)
        return;

      Element element = elements[elementIndex];
      reader.BaseStream.Position = blockOffsetInMeta + element.Offset;

      int count;
      int offset;
      bool accessable;

      uint encoded = 0;
      uint sharedOffset = 0;
      int position = (int)writer.BaseStream.Position;

      switch (element.Type)
      {
        #region block
        case ElementType.Block:
          count = reader.ReadInt32();
          offset = reader.ReadInt32();

          writer.BaseStream.Position = blockOffsetInMap + element.Offset + 4;
          if (count == 0)
            writer.Write(0);
          else
          {
            position = Alignment.Align(position, element.Alignment);
            writer.Write(unchecked(position + magic));
          }
          writer.BaseStream.Position = position;

          if (count > 0)
          {
            reader.BaseStream.Position = offset;
            writer.Write(reader.ReadBytes(element.Size * count));

            for (int i = 0; i < count; i++)
              RecursiveWriteData(reader, writer, extraReader, elements, element.FirstChild, strings, tags, rawBuffer, rawOffset, magic, position + i * element.Size, offset + i * element.Size, myIdentifier);
          }
          break;
        #endregion
        #region string id
        case ElementType.StringID:
          encoded = reader.ReadUInt32();

          if (encoded != 0x0 && encoded != 0xffffffff)
          {
            byte length = (byte)((encoded >> 24) & 0xff);
            reader.BaseStream.Position = encoded & 0x00ffffff;
            string datum = Encoding.ASCII.GetString(reader.ReadBytes(length));

            writer.BaseStream.Position = blockOffsetInMap + element.Offset;
            writer.Write((short)strings.IndexOf(datum));
            writer.Write((byte)0);
            writer.Write(length);
            writer.BaseStream.Position = position;
          }
          break;
        #endregion
        #region tag reference
        case ElementType.TagReference:
          reader.BaseStream.Position -= 4;
          string extension = typeTable.LocateEntryByTypecode(reader.ReadInt32()).FullName;
          encoded = reader.ReadUInt32();

          if (encoded != 0xffffffff && encoded != 0x0)
          {
            byte length = (byte)((encoded >> 24) & 0xff);
            reader.BaseStream.Position = encoded & 0x00ffffff;
            string datum = Encoding.ASCII.GetString(reader.ReadBytes(length));

            writer.BaseStream.Position = blockOffsetInMap + element.Offset;
            writer.Write(tags[datum + '.' + extension]);
            writer.BaseStream.Position = position;
          }
          break;
        #endregion
        #region self reference
        case ElementType.SelfReference:
          encoded = reader.ReadUInt32();

          writer.BaseStream.Position = blockOffsetInMap + element.Offset;
          if (encoded == 0)
            writer.Write(0);
          else if (encoded == 0xffffffff)
            writer.Write(-1);
          else
            writer.Write(myIdentifier);
          break;
        #endregion
        #region predicted resource
        case ElementType.PredictedResource:
          encoded = reader.ReadUInt32();

          if (encoded != 0xffffffff && encoded != 0x0)
          {
            byte length = (byte)((encoded >> 24) & 0xff);
            reader.BaseStream.Position = encoded & 0x00ffffff;
            string datum = Encoding.ASCII.GetString(reader.ReadBytes(length));

            writer.BaseStream.Position = blockOffsetInMap + element.Offset;
            writer.Write(tags[datum]);
            writer.BaseStream.Position = position;
          }
          break;
        #endregion
        #region tag data
        case ElementType.TagData:
          count = reader.ReadInt32();
          offset = reader.ReadInt32();

          writer.BaseStream.Position = blockOffsetInMap + element.Offset + 4;
          if (count == 0)
            writer.Write(0);
          else
          {
            position = Alignment.Align(position, AlignmentConstants.BlockAlignment);
            writer.Write(unchecked(position + magic));
          }
          writer.BaseStream.Position = position;

          if (count > 0)
          {
            reader.BaseStream.Position = offset;
            writer.Write(reader.ReadBytes(count));
          }
          break;
        #endregion
        #region resource block
        case ElementType.ResourceBlock:
          encoded = reader.ReadUInt32();
          count = reader.ReadInt32();
          offset = Conversion.ToInt(encoded & 0x3fffffff);

          writer.BaseStream.Position = blockOffsetInMap + element.Offset;
          if (count == 0)
            writer.Write(0);
          else
          {
            if ((encoded & 0xc0000000) != 0)
            {
              sharedOffset = extraReader.ReadUInt32();

              if ((encoded & 0xc0000000) == 0xc0000000)
                accessable = false;
              else
                accessable = true;
            }
            else
              accessable = false;

            if (accessable)
            {
              writer.Write(sharedOffset);
              writer.BaseStream.Position = position;
              break;
            }
            else
              writer.Write((int)rawBuffer.Length + rawOffset);
          }
          writer.BaseStream.Position = position;

          if (count > 0)
          {
            reader.BaseStream.Position = offset;
            rawBuffer.Write(reader.ReadBytes(count), 0, count);
            rawBuffer.SetLength(Alignment.Align((int)rawBuffer.Length, AlignmentConstants.PageAlignment));
            rawBuffer.Position = rawBuffer.Length;
          }
          break;

        case ElementType.ResourceBlockInverted:
          count = reader.ReadInt32();
          encoded = reader.ReadUInt32();
          offset = Conversion.ToInt(encoded & 0x3fffffff);

          writer.BaseStream.Position = blockOffsetInMap + element.Offset + 4;
          if (count == 0)
            writer.Write(0);
          else
          {
            if ((encoded & 0xc0000000) != 0)
            {
              sharedOffset = extraReader.ReadUInt32();

              if ((encoded & 0xc0000000) == 0xc0000000)
                accessable = false;
              else
                accessable = true;
            }
            else
              accessable = false;

            if (accessable)
            {
              writer.Write(sharedOffset);
              writer.BaseStream.Position = position;
              break;
            }
            else
              writer.Write((int)rawBuffer.Length + rawOffset);
          }
          writer.BaseStream.Position = position;

          if (count > 0)
          {
            reader.BaseStream.Position = offset;
            rawBuffer.Write(reader.ReadBytes(count), 0, count);
            rawBuffer.SetLength(Alignment.Align((int)rawBuffer.Length, AlignmentConstants.PageAlignment));
            rawBuffer.Position = rawBuffer.Length;
          }
          break;
        #endregion
        #region bitmap data
        case ElementType.BitmapData:
          int[] offsets = new int[BitmapLevelCount];
          int[] counts = new int[BitmapLevelCount];

          for (int i = 0; i < BitmapLevelCount; i++)
            offsets[i] = reader.ReadInt32();
          for (int i = 0; i < BitmapLevelCount; i++)
            counts[i] = reader.ReadInt32();

          for (int i = 0; i < BitmapLevelCount; i++)
          {
            if (offsets[i] == -1)
              continue;

            encoded = Conversion.ToUInt(offsets[i]);
            if ((encoded & 0xc0000000) != 0)
            {
              sharedOffset = extraReader.ReadUInt32();

              if ((encoded & 0xc0000000) == 0xc0000000)
                accessable = false;
              else
                accessable = true;
            }
            else
              accessable = false;

            writer.BaseStream.Position = blockOffsetInMap + element.Offset + i * sizeof(int);
            if (accessable)
            {
              writer.Write(sharedOffset);
              writer.BaseStream.Position = position;
              continue;
            }
            else
              writer.Write((int)rawBuffer.Length + rawOffset);
            writer.BaseStream.Position = position;

            reader.BaseStream.Position = offsets[i] & 0x3fffffff;
            rawBuffer.Write(reader.ReadBytes(counts[i]), 0, counts[i]);
            rawBuffer.SetLength(Alignment.Align((int)rawBuffer.Length, AlignmentConstants.PageAlignment));
          }
          break;
        #endregion

        default:
          throw new Exception("Invalid element type or corrupt class file.");
      }

      RecursiveWriteData(reader, writer, extraReader, elements, element.NextSibling, strings, tags, rawBuffer, rawOffset, magic, blockOffsetInMap, blockOffsetInMeta, myIdentifier);
    }

    public string[] GetReferences(string directory, string thisTag, out string[] stringArray)
    {
      Class definition = Singleton<ClassManager>.Instance.GetClassByID(header.Type);
      List<string> references = new List<string>();
      List<string> strings = new List<string>();
      references.Add(thisTag);

      directory += '\\';
      tagData.Position = 0;
      RecursiveGetReferences(new BinaryReader(tagData), references, strings, directory, definition.Elements, definition.RootElementIndex, 0);

      stringArray = strings.ToArray();
      return references.ToArray();
    }

    private void GetReferences(IList<string> references, IList<string> strings, string directory)
    {
      Class definition = Singleton<ClassManager>.Instance.GetClassByID(header.Type);

      tagData.Position = 0;
      RecursiveGetReferences(new BinaryReader(tagData), references, strings, directory, definition.Elements, definition.RootElementIndex, 0);
    }

    private void RecursiveGetReferences(BinaryReader reader, IList<string> references, IList<string> strings, string directory, Element[] elements, int elementIndex, int baseOffset)
    {
      if (elementIndex < 0)
        return;

      Element element = elements[elementIndex];
      reader.BaseStream.Position = baseOffset + element.Offset;

      uint encoded;
      switch (element.Type)
      {
        case ElementType.Block:
          int count = reader.ReadInt32();
          int offset = reader.ReadInt32();
          for (int i = 0; i < count; i++)
            RecursiveGetReferences(reader, references, strings, directory, elements, element.FirstChild, offset + i * element.Size);
          break;

        case ElementType.StringID:
          encoded = reader.ReadUInt32();
          if (encoded != 0xffffffff && encoded != 0x0)
          {
            byte length = (byte)((encoded >> 24) & 0xff);
            reader.BaseStream.Position = encoded & 0x00ffffff;
            string indexedString = Encoding.ASCII.GetString(reader.ReadBytes(length));
            if (!strings.Contains(indexedString))
              strings.Add(indexedString);
          }
          break;

        case ElementType.TagReference:
          encoded = reader.ReadUInt32();
          if (encoded != 0xffffffff && encoded != 0x0)
          {
            byte length = (byte)((encoded >> 24) & 0xff);
            reader.BaseStream.Position = encoded & 0x00ffffff;
            string tagReference = Encoding.ASCII.GetString(reader.ReadBytes(length));
            if (!references.Contains(tagReference))
            {
              references.Add(tagReference);

              using (FileStream stream = File.OpenRead(directory + tagReference))
              {
                Tag recursiveTag = new Tag(new BinaryReader(stream));
                recursiveTag.GetReferences(references, strings, directory);
                stream.Close();
              }
            }
          }
          break;
      }

      RecursiveGetReferences(reader, references, strings, directory, elements, element.NextSibling, baseOffset);
    }

    public static int GetFirstInternalResourceOffset(BinaryReader reader, int type, int magic)
    {
      int offset = -1;
      Class definition = Singleton<ClassManager>.Instance.GetClassByID(type);

      RecursiveGetResourceOffset(reader, ref offset, definition.Elements, definition.RootElementIndex, (int)reader.BaseStream.Position, magic);
      return offset;
    }

    private static void RecursiveGetResourceOffset(BinaryReader reader, ref int offset, Element[] elements, int elementIndex, int baseOffset, int magic)
    {
      if (elementIndex < 0)
        return;

      Element element = elements[elementIndex];
      reader.BaseStream.Position = baseOffset + element.Offset;

      switch (element.Type)
      {
        case ElementType.Block:
          int count = reader.ReadInt32();
          int blockOffset = unchecked(reader.ReadInt32() - magic);
          for (int i = 0; i < count; i++)
            RecursiveGetResourceOffset(reader, ref offset, elements, element.FirstChild, blockOffset + i * element.Size, magic);
          break;

        case ElementType.ResourceBlockInverted:
          reader.BaseStream.Position += 4;
          goto case ElementType.ResourceBlock;

        case ElementType.ResourceBlock:
          uint masked = reader.ReadUInt32();
          if ((masked & 0xc0000000) == 0)
          {
            int unmasked = Conversion.ToInt(masked & 0x3fffffff);
            if (unmasked < offset || offset == -1)
              offset = unmasked;
          }
          break;
      }

      RecursiveGetResourceOffset(reader, ref offset, elements, element.NextSibling, baseOffset, magic);
    }

    public static void ModifyInternalResourceOffsets(BinaryReader reader, BinaryWriter writer, int type, int magic, int modifier)
    {
      Class definition = Singleton<ClassManager>.Instance.GetClassByID(type);
      RecursiveModifyResourceOffsets(reader, writer, definition.Elements, definition.RootElementIndex, (int)reader.BaseStream.Position, magic, modifier);
    }

    private static void RecursiveModifyResourceOffsets(BinaryReader reader, BinaryWriter writer, Element[] elements, int elementIndex, int baseOffset, int magic, int modifier)
    {
      if (elementIndex < 0)
        return;

      Element element = elements[elementIndex];
      reader.BaseStream.Position = baseOffset + element.Offset;

      switch (element.Type)
      {
        case ElementType.Block:
          int count = reader.ReadInt32();
          int offset = unchecked(reader.ReadInt32() - magic);
          for (int i = 0; i < count; i++)
            RecursiveModifyResourceOffsets(reader, writer, elements, element.FirstChild, offset + i * element.Size, magic, modifier);
          break;

        case ElementType.ResourceBlockInverted:
          reader.BaseStream.Position += sizeof(int);
          goto case ElementType.ResourceBlock;

        case ElementType.ResourceBlock:
          uint masked = reader.ReadUInt32();
          if ((masked & 0xc0000000) == 0)
          {
            writer.BaseStream.Position -= sizeof(uint);
            writer.Write(checked(Conversion.ToInt(masked) + modifier));
          }
          break;

        case ElementType.BitmapData:
          for (int i = 0; i < BitmapLevelCount; i++)
          {
            uint bitmapMasked = reader.ReadUInt32();
            if ((bitmapMasked & 0xc0000000) == 0)
            {
              writer.BaseStream.Position -= sizeof(uint);
              writer.Write(checked(Conversion.ToInt(bitmapMasked) + modifier));
            }
          }
          break;
      }

      RecursiveModifyResourceOffsets(reader, writer, elements, element.NextSibling, baseOffset, magic, modifier);
    }

    public static void ModifyBlockOffsets(BinaryReader reader, BinaryWriter writer, IList<int> touched, int type, int magic, int minimumOffset, int modifier)
    {
      Class definition = Singleton<ClassManager>.Instance.GetClassByID(type);
      RecursiveModifyBlockOffsets(reader, writer, touched, definition.Elements, definition.RootElementIndex, (int)reader.BaseStream.Position, magic, minimumOffset, modifier);
    }

    private static void RecursiveModifyBlockOffsets(BinaryReader reader, BinaryWriter writer, IList<int> touched, Element[] elements, int elementIndex, int baseOffset, int magic, int minimumOffset, int modifier)
    {
      if (elementIndex < 0)
        return;

      Element element = elements[elementIndex];
      reader.BaseStream.Position = baseOffset + element.Offset;

      int count;
      int offset;

      switch (element.Type)
      {
        case ElementType.Block:
          if (writer.BaseStream.Position > minimumOffset)
          {
            if (!touched.Contains((int)writer.BaseStream.Position))
            {
              touched.Add((int)writer.BaseStream.Position);

              count = reader.ReadInt32();
              int value = offset = reader.ReadInt32();
              offset = unchecked(offset - magic);

              if (count > 0)
              {
                if (offset < minimumOffset)
                  break;

                writer.BaseStream.Position -= 4;
                writer.Write(value + modifier);
              }

              for (int i = 0; i < count; i++)
                RecursiveModifyBlockOffsets(reader, writer, touched, elements, element.FirstChild, offset + i * element.Size, magic, minimumOffset, modifier);
            }
          }
          break;

        case ElementType.TagData:
          if (!touched.Contains((int)writer.BaseStream.Position))
          {
            touched.Add((int)writer.BaseStream.Position);

            count = reader.ReadInt32();
            offset = reader.ReadInt32();

            if (count > 0)
            {
              if (unchecked(offset - magic) < minimumOffset)
                break;

              writer.BaseStream.Position -= 4;
              writer.Write(offset + modifier);
            }
          }
          break;
      }

      RecursiveModifyBlockOffsets(reader, writer, touched, elements, element.NextSibling, baseOffset, magic, minimumOffset, modifier);
    }

    public int CalculateMetaSize(int offset)
    {
      Class definition = Singleton<ClassManager>.Instance.GetClassByID(header.Type);

      int padding = 0;
      int resourceData = 0;

      tagData.Position = 0;
      RecursiveCalculateMetaSize(new BinaryReader(tagData), definition.Elements, definition.RootElementIndex, ref offset, ref padding, ref resourceData, 0);

      return padding - resourceData + header.TagDataSize;
    }

    private void RecursiveCalculateMetaSize(BinaryReader reader, Element[] elements, int elementIndex, ref int offset, ref int padding, ref int resourceData, int baseOffset)
    {
      if (elementIndex < 0)
        return;

      Element element = elements[elementIndex];
      reader.BaseStream.Position = baseOffset + element.Offset;

      int count;
      int blockOffset;

      switch (element.Type)
      {
        case ElementType.Block:
          count = reader.ReadInt32();
          blockOffset = reader.ReadInt32();
          if (count == 0)
            break;

          int previousOffset = offset;
          offset = Alignment.Align(offset, element.Alignment);
          padding += offset - previousOffset;
          offset += count * element.Size;

          for (int i = 0; i < count; i++)
            RecursiveCalculateMetaSize(reader, elements, element.FirstChild, ref offset, ref padding, ref resourceData, blockOffset + i * element.Size);
          break;

        case ElementType.TagReference:
        case ElementType.StringID:
          uint encoded = reader.ReadUInt32();

          if (encoded == 0xffffffff || encoded == 0x0)
            break;

          byte size = (byte)((encoded >> 24) & 0xff);
          resourceData += size;
          break;

        case ElementType.TagData:
          count = reader.ReadInt32();
          offset += count;
          break;

        case ElementType.ResourceBlockInverted:
          count = reader.ReadInt32();
          resourceData += count;
          break;

        case ElementType.ResourceBlock:
          reader.BaseStream.Position += 4;
          count = reader.ReadInt32();
          resourceData += count;
          break;

        case ElementType.BitmapData:
          reader.BaseStream.Position += 24;
          resourceData += reader.ReadInt32();
          resourceData += reader.ReadInt32();
          resourceData += reader.ReadInt32();
          resourceData += reader.ReadInt32();
          resourceData += reader.ReadInt32();
          resourceData += reader.ReadInt32();
          break;
      }

      RecursiveCalculateMetaSize(reader, elements, element.NextSibling, ref offset, ref padding, ref resourceData, baseOffset);
    }

    private void Flush()
    {
      header.TagDataSize = (int)tagData.Length;
      header.ExtraDataSize = (int)extraData.Length;
    }

    public int Type
    {
      get
      { return header.Type; }
    }
  }
}
