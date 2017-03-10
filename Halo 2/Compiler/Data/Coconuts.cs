using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Games.Halo2.Platforms.Shared;
using Interfaces;

namespace Games.Halo2.Compiler.Data
{
  /// <summary>
  /// This class represents the sound_cache_file_gestalt tag class.
  /// </summary>
  public class Coconuts
  {
    private const int MetaRootSize = 88;

    private List<Playback> playbackParameters;
    private List<Scale> scales;
    private List<string> importNames;
    private List<PitchRangeParametersBlock> pitchRangeParameters;
    private List<PitchRange> pitchRanges;
    private List<Permutation> permutations;
    private List<CustomPlayback> customPlaybacks;
    private List<RuntimePermutationFlags> runtimeFlags;
    private List<Chunk> chunks;
    private List<Promotion> promotions;
    private List<ExtraInfo> extraInfos;

    private List<List<CustomPlayback.Filter>> customFilters;
    private List<List<CustomPlayback.PitchPlaybackParameters>> customPitchParameters;
    private List<List<Promotion.Rule>> promotionRules;
    private List<List<Promotion.Timer>> promotionTimers;
    private List<List<ResourceBlock.Resource>> extraInfoResources;
    private List<byte[]> extraInfoData;

    /// <summary>
    /// Creates a new instance of the Coconuts class and reads its values from a coconuts tag.
    /// </summary>
    public Coconuts(BinaryReader reader, SharedMaps maps, int magic, string[] strings)
    {
      #region header
      int playbackCount = reader.ReadInt32();
      int playbackOffset = unchecked(reader.ReadInt32() - magic);
      int scaleCount = reader.ReadInt32();
      int scaleOffset = unchecked(reader.ReadInt32() - magic);
      int nameCount = reader.ReadInt32();
      int nameOffset = unchecked(reader.ReadInt32() - magic);
      int pitchRangeParameterCount = reader.ReadInt32();
      int pitchRangeParameterOffset = unchecked(reader.ReadInt32() - magic);
      int pitchRangeCount = reader.ReadInt32();
      int pitchRangeOffset = unchecked(reader.ReadInt32() - magic);
      int permutationCount = reader.ReadInt32();
      int permutationOffset = unchecked(reader.ReadInt32() - magic);
      int customPlaybackCount = reader.ReadInt32();
      int customPlaybackOffset = unchecked(reader.ReadInt32() - magic);
      int runtimeFlagsCount = reader.ReadInt32();
      int runtimeFlagsOffset = unchecked(reader.ReadInt32() - magic);
      int chunkCount = reader.ReadInt32();
      int chunkOffset = unchecked(reader.ReadInt32() - magic);
      int promotionCount = reader.ReadInt32();
      int promotionOffset = unchecked(reader.ReadInt32() - magic);
      int extraInfoCount = reader.ReadInt32();
      int extraInfoOffset = unchecked(reader.ReadInt32() - magic);

      if (playbackCount > 0)
        reader.BaseStream.Position = playbackOffset;
      playbackParameters = new List<Playback>(playbackCount);
      for (int i = 0; i < playbackCount; i++)
        playbackParameters.Add(Reinterpret.Memory<Playback>(reader.ReadBytes(Marshal.SizeOf(typeof(Playback)))));

      if (scaleCount > 0)
        reader.BaseStream.Position = scaleOffset;
      scales = new List<Scale>(scaleCount);
      for (int i = 0; i < scaleCount; i++)
        scales.Add(Reinterpret.Memory<Scale>(reader.ReadBytes(Marshal.SizeOf(typeof(Scale)))));

      if (nameCount > 0)
        reader.BaseStream.Position = nameOffset;
      importNames = new List<string>(nameCount);
      for (int i = 0; i < nameCount; i++)
      {
        importNames.Add(strings[reader.ReadInt16()]);
        reader.BaseStream.Position += 2;
      }

      if (pitchRangeParameterCount > 0)
        reader.BaseStream.Position = pitchRangeParameterOffset;
      pitchRangeParameters = new List<PitchRangeParametersBlock>(pitchRangeParameterCount);
      for (int i = 0; i < pitchRangeParameterCount; i++)
        pitchRangeParameters.Add(Reinterpret.Memory<PitchRangeParametersBlock>(reader.ReadBytes(Marshal.SizeOf(typeof(PitchRangeParametersBlock)))));

      if (pitchRangeCount > 0)
        reader.BaseStream.Position = pitchRangeOffset;
      pitchRanges = new List<PitchRange>(pitchRangeCount);
      for (int i = 0; i < pitchRangeCount; i++)
        pitchRanges.Add(Reinterpret.Memory<PitchRange>(reader.ReadBytes(Marshal.SizeOf(typeof(PitchRange)))));

      if (permutationCount > 0)
        reader.BaseStream.Position = permutationOffset;
      permutations = new List<Permutation>(permutationCount);
      for (int i = 0; i < permutationCount; i++)
        permutations.Add(Reinterpret.Memory<Permutation>(reader.ReadBytes(Marshal.SizeOf(typeof(Permutation)))));

      if (customPlaybackCount > 0)
        reader.BaseStream.Position = customPlaybackOffset;
      customPlaybacks = new List<CustomPlayback>(customPlaybackCount);
      for (int i = 0; i < customPlaybackCount; i++)
      {
        CustomPlayback customPlayback = Reinterpret.Memory<CustomPlayback>(reader.ReadBytes(Marshal.SizeOf(typeof(CustomPlayback))));
        unchecked
        {
          customPlayback.FilterOffset -= magic;
          customPlayback.FilterPlaybackParametersOffset -= magic;
          customPlayback.MixFlagsOffset -= magic;
          customPlayback.PitchPlaybackParametersOffset -= magic;
          customPlayback.SoundEffectOffset -= magic;
        }
        customPlaybacks.Add(customPlayback);
      }

      if (runtimeFlagsCount > 0)
        reader.BaseStream.Position = runtimeFlagsOffset;
      runtimeFlags = new List<RuntimePermutationFlags>(runtimeFlagsCount);
      for (int i = 0; i < runtimeFlagsCount; i++)
        runtimeFlags.Add(Reinterpret.Memory<RuntimePermutationFlags>(reader.ReadBytes(Marshal.SizeOf(typeof(RuntimePermutationFlags)))));

      if (chunkCount > 0)
        reader.BaseStream.Position = chunkOffset;
      chunks = new List<Chunk>(chunkCount);
      for (int i = 0; i < chunkCount; i++)
        chunks.Add(Reinterpret.Memory<Chunk>(reader.ReadBytes(Marshal.SizeOf(typeof(Chunk)))));

      if (promotionCount > 0)
        reader.BaseStream.Position = promotionOffset;
      promotions = new List<Promotion>(promotionCount);
      for (int i = 0; i < promotionCount; i++)
      {
        Promotion promotion = Reinterpret.Memory<Promotion>(reader.ReadBytes(Marshal.SizeOf(typeof(Promotion))));
        unchecked
        {
          promotion.RuleOffset -= magic;
          promotion.TimerOffset -= magic;
        }
        promotions.Add(promotion);
      }

      if (extraInfoCount > 0)
        reader.BaseStream.Position = extraInfoOffset;
      extraInfos = new List<ExtraInfo>(extraInfoCount);
      for (int i = 0; i < extraInfoCount; i++)
      {
        ExtraInfo extraInfo = Reinterpret.Memory<ExtraInfo>(reader.ReadBytes(Marshal.SizeOf(typeof(ExtraInfo))));
        extraInfo.ResourceBlock.ResourceOffset = unchecked(extraInfo.ResourceBlock.ResourceOffset - magic);
        extraInfos.Add(extraInfo);
      }
      #endregion

      #region custom playbacks
      customFilters = new List<List<CustomPlayback.Filter>>(customPlaybackCount);
      customPitchParameters = new List<List<CustomPlayback.PitchPlaybackParameters>>(customPlaybackCount);

      for (int i = 0; i < customPlaybackCount; i++)
      {
        customFilters.Add(new List<CustomPlayback.Filter>(customPlaybacks[i].FilterCount));
        if (customPlaybacks[i].FilterCount > 0)
          reader.BaseStream.Position = customPlaybacks[i].FilterOffset;
        for (int j = 0; j < customPlaybacks[i].FilterCount; j++)
          customFilters[i].Add(Reinterpret.Memory<CustomPlayback.Filter>(reader.ReadBytes(Marshal.SizeOf(typeof(CustomPlayback.Filter)))));

        customPitchParameters.Add(new List<CustomPlayback.PitchPlaybackParameters>(customPlaybacks[i].PitchPlaybackParametersCount));
        if (customPlaybacks[i].PitchPlaybackParametersCount > 0)
          reader.BaseStream.Position = customPlaybacks[i].PitchPlaybackParametersOffset;
        for (int j = 0; j < customPlaybacks[i].PitchPlaybackParametersCount; j++)
          customPitchParameters[i].Add(Reinterpret.Memory<CustomPlayback.PitchPlaybackParameters>(reader.ReadBytes(Marshal.SizeOf(typeof(CustomPlayback.PitchPlaybackParameters)))));
      }
      #endregion

      #region promotions
      promotionRules = new List<List<Promotion.Rule>>(promotionCount);
      promotionTimers = new List<List<Promotion.Timer>>(promotionCount);

      for (int i = 0; i < promotionCount; i++)
      {
        promotionRules.Add(new List<Promotion.Rule>(promotions[i].RuleCount));
        if (promotions[i].RuleCount > 0)
          reader.BaseStream.Position = promotions[i].RuleOffset;
        for (int j = 0; j < promotions[i].RuleCount; j++)
          promotionRules[i].Add(Reinterpret.Memory<Promotion.Rule>(reader.ReadBytes(Marshal.SizeOf(typeof(Promotion.Rule)))));

        promotionTimers.Add(new List<Promotion.Timer>(promotions[i].TimerCount));
        if (promotions[i].TimerCount > 0)
          reader.BaseStream.Position = promotions[i].TimerOffset;
        for (int j = 0; j < promotions[i].TimerCount; j++)
          promotionTimers[i].Add(Reinterpret.Memory<Promotion.Timer>(reader.ReadBytes(Marshal.SizeOf(typeof(Promotion.Timer)))));
      }
      #endregion

      #region extra infos
      extraInfoData = new List<byte[]>(extraInfoCount);
      extraInfoResources = new List<List<ResourceBlock.Resource>>(extraInfoCount);

      for (int i = 0; i < extraInfoCount; i++)
      {
        extraInfoData.Add(new byte[extraInfos[i].ResourceBlock.RawSize]);
        if (extraInfos[i].ResourceBlock.RawSize > 0)
        {
          BinaryReader rawReader = maps.GetMap(extraInfos[i].ResourceBlock.RawOffset, reader);
          if (rawReader != null)
            for (int j = 0; j < extraInfos[i].ResourceBlock.RawSize; j++)
              extraInfoData[i][j] = rawReader.ReadByte();

        extraInfoResources.Add(new List<ResourceBlock.Resource>(extraInfos[i].ResourceBlock.ResourceCount));
        if (extraInfos[i].ResourceBlock.ResourceCount > 0)
          reader.BaseStream.Position = extraInfos[i].ResourceBlock.ResourceOffset;
        for (int j = 0; j < extraInfos[i].ResourceBlock.ResourceCount; j++)
          extraInfoResources[i].Add(Reinterpret.Memory<ResourceBlock.Resource>(reader.ReadBytes(Marshal.SizeOf(typeof(ResourceBlock.Resource)))));
        }
      }
      #endregion
    }

    public Coconuts()
    {
      playbackParameters = new List<Playback>();
      scales = new List<Scale>();
      importNames = new List<string>();
      pitchRangeParameters = new List<PitchRangeParametersBlock>();
      pitchRanges = new List<PitchRange>();
      permutations = new List<Permutation>();
      customPlaybacks = new List<CustomPlayback>();
      runtimeFlags = new List<RuntimePermutationFlags>();
      chunks = new List<Chunk>();
      promotions = new List<Promotion>();
      extraInfos = new List<ExtraInfo>();

      customFilters = new List<List<CustomPlayback.Filter>>();
      customPitchParameters = new List<List<CustomPlayback.PitchPlaybackParameters>>();
      promotionRules = new List<List<Promotion.Rule>>();
      promotionTimers = new List<List<Promotion.Timer>>();
      extraInfoResources = new List<List<ResourceBlock.Resource>>();
      extraInfoData = new List<byte[]>();
    }

    public void WriteToDataStream(BinaryWriter writer)
    {
      int currentEnd = (int)writer.BaseStream.Position + MetaRootSize;

      int importNameBlockSize = 0;
      for (int i = 0; i < importNames.Count; i++)
        importNameBlockSize += importNames[i].Length;

      // tier 0
      writer.Write(playbackParameters.Count);
      writer.Write(currentEnd);
      currentEnd += playbackParameters.Count * Marshal.SizeOf(typeof(Playback));

      writer.Write(scales.Count);
      writer.Write(currentEnd);
      currentEnd += scales.Count * Marshal.SizeOf(typeof(Scale));

      writer.Write(importNames.Count);
      writer.Write(currentEnd);
      currentEnd += importNames.Count * sizeof(byte) + importNameBlockSize;

      writer.Write(pitchRangeParameters.Count);
      writer.Write(currentEnd);
      currentEnd += pitchRangeParameters.Count * Marshal.SizeOf(typeof(PitchRangeParametersBlock));

      writer.Write(pitchRanges.Count);
      writer.Write(currentEnd);
      currentEnd += pitchRanges.Count * Marshal.SizeOf(typeof(PitchRange));

      writer.Write(permutations.Count);
      writer.Write(currentEnd);
      currentEnd += permutations.Count * Marshal.SizeOf(typeof(Permutation));

      writer.Write(customPlaybacks.Count);
      writer.Write(currentEnd);
      currentEnd += customPlaybacks.Count * Marshal.SizeOf(typeof(CustomPlayback));

      writer.Write(runtimeFlags.Count);
      writer.Write(currentEnd);
      currentEnd += runtimeFlags.Count * Marshal.SizeOf(typeof(RuntimePermutationFlags));

      writer.Write(chunks.Count);
      writer.Write(currentEnd);
      currentEnd += chunks.Count * Marshal.SizeOf(typeof(Chunk));

      writer.Write(promotions.Count);
      writer.Write(currentEnd);
      currentEnd += promotions.Count * Marshal.SizeOf(typeof(Promotion));

      writer.Write(extraInfos.Count);
      writer.Write(currentEnd);
      currentEnd += extraInfos.Count * Marshal.SizeOf(typeof(ExtraInfo));

      // tier 1
      for (int i = 0; i < playbackParameters.Count; i++)
        writer.Write(Reinterpret.Object<Playback>(playbackParameters[i]));

      for (int i = 0; i < scales.Count; i++)
        writer.Write(Reinterpret.Object<Scale>(scales[i]));

      for (int i = 0; i < importNames.Count; i++)
      {
        writer.Write((byte)Encoding.ASCII.GetByteCount(importNames[i]));
        writer.Write(Encoding.ASCII.GetBytes(importNames[i]));
      }

      for (int i = 0; i < pitchRangeParameters.Count; i++)
        writer.Write(Reinterpret.Object<PitchRangeParametersBlock>(pitchRangeParameters[i]));

      for (int i = 0; i < pitchRanges.Count; i++)
        writer.Write(Reinterpret.Object<PitchRange>(pitchRanges[i]));

      for (int i = 0; i < permutations.Count; i++)
        writer.Write(Reinterpret.Object<Permutation>(permutations[i]));

      for (int i = 0; i < customPlaybacks.Count; i++)
      {
        CustomPlayback customPlayback = customPlaybacks[i];

        if (customPlayback.FilterCount > 0)
        {
          customPlayback.FilterOffset = currentEnd;
          currentEnd += customPlayback.FilterCount * Marshal.SizeOf(typeof(CustomPlayback.Filter));
        }
        else
          customPlayback.FilterOffset = 0;

        if (customPlayback.PitchPlaybackParametersCount > 0)
        {
          customPlayback.PitchPlaybackParametersOffset = currentEnd;
          currentEnd += customPlayback.PitchPlaybackParametersCount * Marshal.SizeOf(typeof(CustomPlayback.PitchPlaybackParameters));
        }
        else
          customPlayback.PitchPlaybackParametersOffset = 0;

        writer.Write(Reinterpret.Object<CustomPlayback>(customPlayback));
      }

      for (int i = 0; i < runtimeFlags.Count; i++)
        writer.Write(Reinterpret.Object<RuntimePermutationFlags>(runtimeFlags[i]));

      for (int i = 0; i < chunks.Count; i++)
        writer.Write(Reinterpret.Object<Chunk>(chunks[i]));

      for (int i = 0; i < promotions.Count; i++)
      {
        Promotion promotion = promotions[i];

        if (promotion.RuleCount > 0)
        {
          promotion.RuleOffset = currentEnd;
          currentEnd += promotion.RuleCount * Marshal.SizeOf(typeof(Promotion.Rule));
        }
        else
          promotion.RuleOffset = 0;

        if (promotion.TimerCount > 0)
        {
          promotion.TimerOffset = currentEnd;
          currentEnd += promotion.TimerCount * Marshal.SizeOf(typeof(Promotion.Timer));
        }
        else
          promotion.TimerOffset = 0;

        writer.Write(Reinterpret.Object<Promotion>(promotion));
      }

      for (int i = 0; i < extraInfos.Count; i++)
      {
        ExtraInfo extraInfo = extraInfos[i];

        if (extraInfo.ResourceBlock.RawSize > 0)
        {
          uint encoded = Conversion.ToUInt(currentEnd) & 0x3fffffff;
          encoded |= Conversion.ToUInt(extraInfo.ResourceBlock.RawOffset) & 0xc0000000;
          extraInfo.ResourceBlock.RawOffset = Conversion.ToInt(encoded);
          currentEnd += extraInfo.ResourceBlock.RawSize * sizeof(byte);
        }
        else
          extraInfo.ResourceBlock.RawOffset = 0;

        if (extraInfo.ResourceBlock.ResourceCount > 0)
        {
          extraInfo.ResourceBlock.ResourceOffset = currentEnd;
          currentEnd += extraInfo.ResourceBlock.ResourceCount * Marshal.SizeOf(typeof(ResourceBlock.Resource));
        }
        else
          extraInfo.ResourceBlock.ResourceOffset = 0;

        writer.Write(Reinterpret.Object<ExtraInfo>(extraInfo));
      }

      // tier 2
      for (int i = 0; i < customPlaybacks.Count; i++)
      {
        for (int j = 0; j < customPlaybacks[i].FilterCount; j++)
          writer.Write(Reinterpret.Object<CustomPlayback.Filter>(customFilters[i][j]));
        for (int j = 0; j < customPlaybacks[i].PitchPlaybackParametersCount; j++)
          writer.Write(Reinterpret.Object<CustomPlayback.PitchPlaybackParameters>(customPitchParameters[i][j]));
      }

      for (int i = 0; i < promotions.Count; i++)
      {
        for (int j = 0; j < promotions[i].RuleCount; j++)
          writer.Write(Reinterpret.Object<Promotion.Rule>(promotionRules[i][j]));
        for (int j = 0; j < promotions[i].TimerCount; j++)
          writer.Write(Reinterpret.Object<Promotion.Timer>(promotionTimers[i][j]));
      }

      for (int i = 0; i < extraInfos.Count; i++)
      {
        for (int j = 0; j < extraInfos[i].ResourceBlock.RawSize; j++)
          writer.Write(extraInfoData[i][j]);
        for (int j = 0; j < extraInfos[i].ResourceBlock.ResourceCount; j++)
          writer.Write(Reinterpret.Object<ResourceBlock.Resource>(extraInfoResources[i][j]));
      }
    }

    public void WriteToMapStream(BinaryWriter writer, IList<string> strings, int magic)
    {
      int currentEnd;

      unchecked
      {
        magic += (int)writer.BaseStream.Position;
        currentEnd = MetaRootSize + magic;
      }

      // tier 0
      writer.Write(playbackParameters.Count);
      writer.Write(currentEnd);
      currentEnd += playbackParameters.Count * Marshal.SizeOf(typeof(Playback));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(scales.Count);
      writer.Write(currentEnd);
      currentEnd += scales.Count * Marshal.SizeOf(typeof(Scale));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(importNames.Count);
      writer.Write(currentEnd);
      currentEnd += importNames.Count * Marshal.SizeOf(typeof(ImportName));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(pitchRangeParameters.Count);
      writer.Write(currentEnd);
      currentEnd += pitchRangeParameters.Count * Marshal.SizeOf(typeof(PitchRangeParametersBlock));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(pitchRanges.Count);
      writer.Write(currentEnd);
      currentEnd += pitchRanges.Count * Marshal.SizeOf(typeof(PitchRange));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(permutations.Count);
      writer.Write(currentEnd);
      currentEnd += permutations.Count * Marshal.SizeOf(typeof(Permutation));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(customPlaybacks.Count);
      writer.Write(currentEnd);
      currentEnd += customPlaybacks.Count * Marshal.SizeOf(typeof(CustomPlayback));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(runtimeFlags.Count);
      writer.Write(currentEnd);
      currentEnd += runtimeFlags.Count * Marshal.SizeOf(typeof(RuntimePermutationFlags));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(chunks.Count);
      writer.Write(currentEnd);
      currentEnd += chunks.Count * Marshal.SizeOf(typeof(Chunk));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(promotions.Count);
      writer.Write(currentEnd);
      currentEnd += promotions.Count * Marshal.SizeOf(typeof(Promotion));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      writer.Write(extraInfos.Count);
      writer.Write(currentEnd);
      currentEnd += extraInfos.Count * Marshal.SizeOf(typeof(ExtraInfo));
      currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);

      // tier 1
      for (int i = 0; i < playbackParameters.Count; i++)
        writer.Write(Reinterpret.Object<Playback>(playbackParameters[i]));
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < scales.Count; i++)
        writer.Write(Reinterpret.Object<Scale>(scales[i]));
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < importNames.Count; i++)
      {
        ImportName importName = new ImportName();
        short index = (short)strings.IndexOf(importNames[i]);
        if (index >= 0)
        {
          importName.Index = index;
          importName.Size = (byte)importNames[i].Length;
        }
        writer.Write(Reinterpret.Object<ImportName>(importName));
      }
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < pitchRangeParameters.Count; i++)
        writer.Write(Reinterpret.Object<PitchRangeParametersBlock>(pitchRangeParameters[i]));
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < pitchRanges.Count; i++)
        writer.Write(Reinterpret.Object<PitchRange>(pitchRanges[i]));
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < permutations.Count; i++)
        writer.Write(Reinterpret.Object<Permutation>(permutations[i]));
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < customPlaybacks.Count; i++)
      {
        CustomPlayback customPlayback = customPlaybacks[i];

        if (customPlayback.FilterCount > 0)
        {
          customPlayback.FilterOffset = currentEnd;
          currentEnd += customPlayback.FilterCount * Marshal.SizeOf(typeof(CustomPlayback.Filter));
          currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);
        }
        else
          customPlayback.FilterOffset = 0;

        if (customPlayback.PitchPlaybackParametersCount > 0)
        {
          customPlayback.PitchPlaybackParametersOffset = currentEnd;
          currentEnd += customPlayback.PitchPlaybackParametersCount * Marshal.SizeOf(typeof(CustomPlayback.PitchPlaybackParameters));
          currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);
        }
        else
          customPlayback.PitchPlaybackParametersOffset = 0;

        writer.Write(Reinterpret.Object<CustomPlayback>(customPlayback));
      }
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < runtimeFlags.Count; i++)
        writer.Write(Reinterpret.Object<RuntimePermutationFlags>(runtimeFlags[i]));
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < chunks.Count; i++)
        writer.Write(Reinterpret.Object<Chunk>(chunks[i]));
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < promotions.Count; i++)
      {
        Promotion promotion = promotions[i];

        if (promotion.RuleCount > 0)
        {
          promotion.RuleOffset = currentEnd;
          currentEnd += promotion.RuleCount * Marshal.SizeOf(typeof(Promotion.Rule));
          currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);
        }
        else
          promotion.RuleOffset = 0;

        if (promotion.TimerCount > 0)
        {
          promotion.TimerOffset = currentEnd;
          currentEnd += promotion.TimerCount * Marshal.SizeOf(typeof(Promotion.Timer));
          currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);
        }
        else
          promotion.TimerOffset = 0;

        writer.Write(Reinterpret.Object<Promotion>(promotion));
      }
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      for (int i = 0; i < extraInfos.Count; i++)
      {
        ExtraInfo extraInfo = extraInfos[i];

        if (extraInfo.ResourceBlock.ResourceCount > 0)
        {
          extraInfo.ResourceBlock.ResourceOffset = currentEnd;
          currentEnd += extraInfo.ResourceBlock.ResourceCount * Marshal.SizeOf(typeof(ResourceBlock.Resource));
          currentEnd = Alignment.Align(currentEnd, AlignmentConstants.BlockAlignment);
        }
        else
          extraInfo.ResourceBlock.ResourceOffset = 0;

        writer.Write(Reinterpret.Object<ExtraInfo>(extraInfo));
      }
      writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);

      // tier 2
      for (int i = 0; i < customPlaybacks.Count; i++)
      {
        for (int j = 0; j < customPlaybacks[i].FilterCount; j++)
          writer.Write(Reinterpret.Object<CustomPlayback.Filter>(customFilters[i][j]));
        writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);
        for (int j = 0; j < customPlaybacks[i].PitchPlaybackParametersCount; j++)
          writer.Write(Reinterpret.Object<CustomPlayback.PitchPlaybackParameters>(customPitchParameters[i][j]));
        writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);
      }

      for (int i = 0; i < promotions.Count; i++)
      {
        for (int j = 0; j < promotions[i].RuleCount; j++)
          writer.Write(Reinterpret.Object<Promotion.Rule>(promotionRules[i][j]));
        writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);
        for (int j = 0; j < promotions[i].TimerCount; j++)
          writer.Write(Reinterpret.Object<Promotion.Timer>(promotionTimers[i][j]));
        writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);
      }

      for (int i = 0; i < extraInfos.Count; i++)
      {
        for (int j = 0; j < extraInfos[i].ResourceBlock.ResourceCount; j++)
          writer.Write(Reinterpret.Object<ResourceBlock.Resource>(extraInfoResources[i][j]));
        writer.BaseStream.Position = Alignment.Align((int)writer.BaseStream.Position, AlignmentConstants.BlockAlignment);
      }
    }

    /// <summary>
    /// Represents the block at 0 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Playback
    {
      public float MinimumDistance;
      public float MaximumDistance;
      public float SkipFraction;
      public float MaximumBend;
      public float GainBase;
      public float GainVariance;
      public short RandomPitchBoundsLower;
      public short RandomPitchBoundsUpper;
      public float InnerConeAngle;
      public float OuterConeAngle;
      public float OuterConeGain;
      public int Flags;
      public float Azimuth;
      public float PositionalGain;
      public float FirstPersonGain;
    }

    /// <summary>
    /// Represents the block at 8 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Scale
    {
      public float GainModifierBoundsLower;
      public float GainModifierBoundsUpper;
      public short PitchModifierBoundsLower;
      public short PitchModifierBoundsUpper;
      public float SkipFractionModifierBoundsLower;
      public float SkipFractionModifierBoundsUpper;
    }

    /// <summary>
    /// Represents the block at 16 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ImportName
    {
      public short Index;
      private byte zero;
      public byte Size;
    }

    /// <summary>
    /// Represents the block at 24 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PitchRangeParametersBlock
    {
      public short NaturalPitch;
      public short BendBoundsLower;
      public short BendBoundsUpper;
      public short MaxGainPitchBoundsLower;
      public short MaxGainPitchBoundsUpper;
    }

    /// <summary>
    /// Represents the block at 32 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PitchRange
    {
      public short NameBlockIndex;
      public short ParametersBlockIndex;
      public short EncodedPermutationData;
      public short FirstRuntimePermutationFlagIndex;
      public short FirstPermutationIndex;
      public short PermutationCount;
    }

    /// <summary>
    /// Represents the block at 40 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Permutation
    {
      public short NameBlockIndex;
      public short EncodedSkipFraction;
      public byte EncodedGain;
      public sbyte PermutationInfoIndex;
      public short LanguageNeutralTime;
      public int SampleSize;
      public short FirstChunkIndex;
      public short ChunkCount;
    }

    /// <summary>
    /// Represents the insane block at 48 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct CustomPlayback
    {
      public int MixFlagsCount;
      public int MixFlagsOffset;
      public int Flags;
      private fixed byte a[8];
      public int FilterCount;
      public int FilterOffset;
      public int PitchPlaybackParametersCount;
      public int PitchPlaybackParametersOffset;
      public int FilterPlaybackParametersCount;
      public int FilterPlaybackParametersOffset;
      public int SoundEffectCount;
      public int SoundEffectOffset;

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public struct Filter
      {
        public int FilterType;
        public int FilterWidth;
        public float LeftFilterFrequencyScaleBoundsLower;
        public float LeftFilterFrequencyScaleBoundsUpper;
        public float LeftFilterFrequencyBaseBoundsLower;
        public float LeftFilterFrequencyBaseBoundsUpper;
        public float LeftFilterGainScaleBoundsLower;
        public float LeftFilterGainScaleBoundsUpper;
        public float LeftFilterGainBaseBoundsLower;
        public float LeftFilterGainBaseBoundsUpper;
        public float RightFilterFrequencyScaleBoundsLower;
        public float RightFilterFrequencyScaleBoundsUpper;
        public float RightFilterFrequencyBaseBoundsLower;
        public float RightFilterFrequencyBaseBoundsUpper;
        public float RightFilterGainScaleBoundsLower;
        public float RightFilterGainScaleBoundsUpper;
        public float RightFilterGainBaseBoundsLower;
        public float RightFilterGainBaseBoundsUpper;
      }

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public struct PitchPlaybackParameters
      {
        public float DelayScaleBoundsLower;
        public float DelayScaleBoundsUpper;
        public float DelayBaseBoundsLower;
        public float DelayBaseBoundsUpper;
        public float FrequencyScaleBoundsLower;
        public float FrequencyScaleBoundsUpper;
        public float FrequencyBaseBoundsLower;
        public float FrequencyBaseBoundsUpper;
        public float PitchModulationScaleBoundsLower;
        public float PitchModulationScaleBoundsUpper;
        public float PitchModulationBaseBoundsLower;
        public float PitchModulationBaseBoundsUpper;
      }
    }

    /// <summary>
    /// Represents the block at 56 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RuntimePermutationFlags
    {
      private byte unknown;
    }

    /// <summary>
    /// Represents the block at 64 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Chunk
    {
      public int Offset;
      public ushort Size;
      private short unknown;
      private int negativeOne;
    }

    /// <summary>
    /// Represents the block at 72 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Promotion
    {
      public int RuleCount;
      public int RuleOffset;
      public int TimerCount;
      public int TimerOffset;
      private fixed byte a[12];

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public struct Rule
      {
        public short PitchRangeIndex;
        public short MaximumPlayingCount;
        public float SuppressionTime;
        private fixed byte a[8];
      }

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public struct Timer
      {
        private int value;
      }
    }

    /// <summary>
    /// Represents the block at 80 bytes into the file.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ExtraInfo
    {
      public int EncodedPermutationCount;
      public int EncodedPermutationOffset;
      public ResourceBlock ResourceBlock;
    }

    public List<string> ImportNames
    {
      get
      { return importNames; }
    }

    public List<PitchRangeParametersBlock> PitchRangeParameters
    {
      get
      { return pitchRangeParameters; }
    }

    public List<PitchRange> PitchRanges
    {
      get
      { return pitchRanges; }
    }

    public List<Permutation> Permutations
    {
      get
      { return permutations; }
    }

    public List<Chunk> Chunks
    {
      get
      { return chunks; }
    }

    public List<Promotion> Promotions
    {
      get
      { return promotions; }
    }

    public List<List<Promotion.Rule>> PromotionRules
    {
      get
      { return promotionRules; }
    }

    public List<List<Promotion.Timer>> PromotionTimers
    {
      get
      { return promotionTimers; }
    }

    public List<RuntimePermutationFlags> RuntimeFlags
    {
      get
      { return runtimeFlags; }
    }

    public List<CustomPlayback> CustomPlaybacks
    {
      get
      { return customPlaybacks; }
    }

    public List<List<CustomPlayback.Filter>> CustomFilters
    {
      get
      { return customFilters; }
    }

    public List<List<CustomPlayback.PitchPlaybackParameters>> CustomPitchParameters
    {
      get
      { return customPitchParameters; }
    }

    public List<ExtraInfo> ExtraInfos
    {
      get
      { return extraInfos; }
    }

    public List<List<ResourceBlock.Resource>> ExtraInfoResources
    {
      get
      { return extraInfoResources; }
    }

    public List<byte[]> ExtraInfoData
    {
      get
      { return extraInfoData; }
    }

    public List<Playback> PlaybackParameters
    {
      get
      { return playbackParameters; }
    }

    public List<Scale> Scales
    {
      get
      { return scales; }
    }
  }
}
