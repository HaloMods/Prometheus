// -------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'unit' (derived from 'object')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// -------------------------------------------------
namespace Games.Halo.Tags.Classes
{
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;

  public partial class unit : @object
  {
    private UnitBlock unitValues = new UnitBlock();
    public virtual UnitBlock UnitValues
    {
      get
      {
        return unitValues;
      }
    }
    public override string[] TagReferenceList
    {
      get
      {
        UniqueStringCollection references = new UniqueStringCollection();
        references.AddRange(base.TagReferenceList);
        references.AddRange(UnitValues.TagReferenceList);
        return references.ToArray();
      }
    }
    public override string FileExtension
    {
      get
      {
        return "unit";
      }
    }
    #region Read/Write Methods
    public override int Load(byte[] metadata)
    {
      System.IO.BinaryReader reader = new System.IO.BinaryReader(new System.IO.MemoryStream(metadata));
      Read(reader);
      int position = (int)reader.BaseStream.Position;
      ReadChildData(reader);
      reader.Close();
      return position;
    }
    public override void Read(BinaryReader reader)
    {
      base.Read(reader);
      unitValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader)
    {
      base.ReadChildData(reader);
      unitValues.ReadChildData(reader);
    }
    public override byte[] Save()
    {
      BinaryWriter writer = new BinaryWriter(new MemoryStream());
      Write(writer);
      WriteChildData(writer);
      return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer)
    {
      base.Write(writer);
      unitValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer)
    {
      base.WriteChildData(writer);
      unitValues.WriteChildData(writer);
    }
    #endregion
    public class UnitBlock : IBlock
    {
      private Flags _flags;
      private Enum _defaultTeam = new Enum();
      private Enum _constantSoundVolume = new Enum();
      private Real _riderDamageFraction = new Real();
      private TagReference _integratedLightToggle = new TagReference();
      private Enum _aIn = new Enum();
      private Enum _bIn = new Enum();
      private Enum _cIn = new Enum();
      private Enum _dIn = new Enum();
      private Angle _cameraFieldOfView = new Angle();
      private Real _cameraStiffness = new Real();
      private FixedLengthString _cameraMarkerName = new FixedLengthString();
      private FixedLengthString _cameraSubmergedMarkerName = new FixedLengthString();
      private Angle _pitchAut = new Angle();
      private AngleBounds _pitchRange = new AngleBounds();
      private Block _cameraTracks = new Block();
      private RealVector3D _seatAccelerationScale = new RealVector3D();
      private Pad _unnamed;
      private Real _softPingThreshold = new Real();
      private Real _softPingInterruptTime = new Real();
      private Real _hardPingThreshold = new Real();
      private Real _hardPingInterruptTime = new Real();
      private Real _hardDeathThreshold = new Real();
      private Real _feignDeathThreshold = new Real();
      private Real _feignDeathTime = new Real();
      private Real _distanceOfEvadeAnim = new Real();
      private Real _distanceOfDiveAnim = new Real();
      private Pad _unnamed2;
      private Real _stunnedMovementThreshold = new Real();
      private Real _feignDeathChance = new Real();
      private Real _feignRepeatChance = new Real();
      private TagReference _spawnedActor = new TagReference();
      private ShortBounds _spawnedActorCount = new ShortBounds();
      private Real _spawnedVelocity = new Real();
      private Angle _aimingVelocityMaximum = new Angle();
      private Angle _aimingAccelerationMaximum = new Angle();
      private RealFraction _casualAimingModifier = new RealFraction();
      private Angle _lookingVelocityMaximum = new Angle();
      private Angle _lookingAccelerationMaximum = new Angle();
      private Pad _unnamed3;
      private Real _aIVehicleRadius = new Real();
      private Real _aIDangerRadius = new Real();
      private TagReference _meleeDamage = new TagReference();
      private Enum _motionSensorBlipSize = new Enum();
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Block _nEWHUDINTERFACES = new Block();
      private Block _dialogueVariants = new Block();
      private Real _grenadeVelocity = new Real();
      private Enum _grenadeType = new Enum();
      private ShortInteger _grenadeCount = new ShortInteger();
      private Pad _unnamed6;
      private Block _poweredSeats = new Block();
      private Block _weapons = new Block();
      private Block _seats = new Block();
      public BlockCollection<UnitCameraTrackBlock> _cameraTracksList = new BlockCollection<UnitCameraTrackBlock>();
      public BlockCollection<UnitHudReferenceBlock> _nEWHUDINTERFACESList = new BlockCollection<UnitHudReferenceBlock>();
      public BlockCollection<DialogueVariantBlock> _dialogueVariantsList = new BlockCollection<DialogueVariantBlock>();
      public BlockCollection<PoweredSeatBlock> _poweredSeatsList = new BlockCollection<PoweredSeatBlock>();
      public BlockCollection<UnitWeaponBlock> _weaponsList = new BlockCollection<UnitWeaponBlock>();
      public BlockCollection<UnitSeatBlock> _seatsList = new BlockCollection<UnitSeatBlock>();
      public event System.EventHandler BlockNameChanged;
      public UnitBlock()
      {
        this._flags = new Flags(4);
        this._unnamed = new Pad(12);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(12);
        this._unnamed6 = new Pad(4);
      }
      public BlockCollection<UnitCameraTrackBlock> CameraTracks
      {
        get
        {
          return this._cameraTracksList;
        }
      }
      public BlockCollection<UnitHudReferenceBlock> NEWHUDINTERFACES
      {
        get
        {
          return this._nEWHUDINTERFACESList;
        }
      }
      public BlockCollection<DialogueVariantBlock> DialogueVariants
      {
        get
        {
          return this._dialogueVariantsList;
        }
      }
      public BlockCollection<PoweredSeatBlock> PoweredSeats
      {
        get
        {
          return this._poweredSeatsList;
        }
      }
      public BlockCollection<UnitWeaponBlock> Weapons
      {
        get
        {
          return this._weaponsList;
        }
      }
      public BlockCollection<UnitSeatBlock> Seats
      {
        get
        {
          return this._seatsList;
        }
      }
      public virtual string[] TagReferenceList
      {
        get
        {
          UniqueStringCollection references = new UniqueStringCollection();
          references.Add(_integratedLightToggle.Value);
          references.Add(_spawnedActor.Value);
          references.Add(_meleeDamage.Value);
          for (int x = 0; x < CameraTracks.BlockCount; x++)
          {
            IBlock block = CameraTracks.GetBlock(x);
            references.AddRange(block.TagReferenceList);
          }
          for (int x = 0; x < NEWHUDINTERFACES.BlockCount; x++)
          {
            IBlock block = NEWHUDINTERFACES.GetBlock(x);
            references.AddRange(block.TagReferenceList);
          }
          for (int x = 0; x < DialogueVariants.BlockCount; x++)
          {
            IBlock block = DialogueVariants.GetBlock(x);
            references.AddRange(block.TagReferenceList);
          }
          for (int x = 0; x < PoweredSeats.BlockCount; x++)
          {
            IBlock block = PoweredSeats.GetBlock(x);
            references.AddRange(block.TagReferenceList);
          }
          for (int x = 0; x < Weapons.BlockCount; x++)
          {
            IBlock block = Weapons.GetBlock(x);
            references.AddRange(block.TagReferenceList);
          }
          for (int x = 0; x < Seats.BlockCount; x++)
          {
            IBlock block = Seats.GetBlock(x);
            references.AddRange(block.TagReferenceList);
          }
          return references.ToArray();
        }
      }
      public virtual string BlockName
      {
        get
        {
          return "";
        }
      }
      public Flags Flags
      {
        get
        {
          return this._flags;
        }
        set
        {
          this._flags = value;
        }
      }
      public Enum DefaultTeam
      {
        get
        {
          return this._defaultTeam;
        }
        set
        {
          this._defaultTeam = value;
        }
      }
      public Enum ConstantSoundVolume
      {
        get
        {
          return this._constantSoundVolume;
        }
        set
        {
          this._constantSoundVolume = value;
        }
      }
      public Real RiderDamageFraction
      {
        get
        {
          return this._riderDamageFraction;
        }
        set
        {
          this._riderDamageFraction = value;
        }
      }
      public TagReference IntegratedLightToggle
      {
        get
        {
          return this._integratedLightToggle;
        }
        set
        {
          this._integratedLightToggle = value;
        }
      }
      public Enum AIn
      {
        get
        {
          return this._aIn;
        }
        set
        {
          this._aIn = value;
        }
      }
      public Enum BIn
      {
        get
        {
          return this._bIn;
        }
        set
        {
          this._bIn = value;
        }
      }
      public Enum CIn
      {
        get
        {
          return this._cIn;
        }
        set
        {
          this._cIn = value;
        }
      }
      public Enum DIn
      {
        get
        {
          return this._dIn;
        }
        set
        {
          this._dIn = value;
        }
      }
      public Angle CameraFieldOfView
      {
        get
        {
          return this._cameraFieldOfView;
        }
        set
        {
          this._cameraFieldOfView = value;
        }
      }
      public Real CameraStiffness
      {
        get
        {
          return this._cameraStiffness;
        }
        set
        {
          this._cameraStiffness = value;
        }
      }
      public FixedLengthString CameraMarkerName
      {
        get
        {
          return this._cameraMarkerName;
        }
        set
        {
          this._cameraMarkerName = value;
        }
      }
      public FixedLengthString CameraSubmergedMarkerName
      {
        get
        {
          return this._cameraSubmergedMarkerName;
        }
        set
        {
          this._cameraSubmergedMarkerName = value;
        }
      }
      public Angle PitchAut
      {
        get
        {
          return this._pitchAut;
        }
        set
        {
          this._pitchAut = value;
        }
      }
      public AngleBounds PitchRange
      {
        get
        {
          return this._pitchRange;
        }
        set
        {
          this._pitchRange = value;
        }
      }
      public RealVector3D SeatAccelerationScale
      {
        get
        {
          return this._seatAccelerationScale;
        }
        set
        {
          this._seatAccelerationScale = value;
        }
      }
      public Real SoftPingThreshold
      {
        get
        {
          return this._softPingThreshold;
        }
        set
        {
          this._softPingThreshold = value;
        }
      }
      public Real SoftPingInterruptTime
      {
        get
        {
          return this._softPingInterruptTime;
        }
        set
        {
          this._softPingInterruptTime = value;
        }
      }
      public Real HardPingThreshold
      {
        get
        {
          return this._hardPingThreshold;
        }
        set
        {
          this._hardPingThreshold = value;
        }
      }
      public Real HardPingInterruptTime
      {
        get
        {
          return this._hardPingInterruptTime;
        }
        set
        {
          this._hardPingInterruptTime = value;
        }
      }
      public Real HardDeathThreshold
      {
        get
        {
          return this._hardDeathThreshold;
        }
        set
        {
          this._hardDeathThreshold = value;
        }
      }
      public Real FeignDeathThreshold
      {
        get
        {
          return this._feignDeathThreshold;
        }
        set
        {
          this._feignDeathThreshold = value;
        }
      }
      public Real FeignDeathTime
      {
        get
        {
          return this._feignDeathTime;
        }
        set
        {
          this._feignDeathTime = value;
        }
      }
      public Real DistanceOfEvadeAnim
      {
        get
        {
          return this._distanceOfEvadeAnim;
        }
        set
        {
          this._distanceOfEvadeAnim = value;
        }
      }
      public Real DistanceOfDiveAnim
      {
        get
        {
          return this._distanceOfDiveAnim;
        }
        set
        {
          this._distanceOfDiveAnim = value;
        }
      }
      public Real StunnedMovementThreshold
      {
        get
        {
          return this._stunnedMovementThreshold;
        }
        set
        {
          this._stunnedMovementThreshold = value;
        }
      }
      public Real FeignDeathChance
      {
        get
        {
          return this._feignDeathChance;
        }
        set
        {
          this._feignDeathChance = value;
        }
      }
      public Real FeignRepeatChance
      {
        get
        {
          return this._feignRepeatChance;
        }
        set
        {
          this._feignRepeatChance = value;
        }
      }
      public TagReference SpawnedActor
      {
        get
        {
          return this._spawnedActor;
        }
        set
        {
          this._spawnedActor = value;
        }
      }
      public ShortBounds SpawnedActorCount
      {
        get
        {
          return this._spawnedActorCount;
        }
        set
        {
          this._spawnedActorCount = value;
        }
      }
      public Real SpawnedVelocity
      {
        get
        {
          return this._spawnedVelocity;
        }
        set
        {
          this._spawnedVelocity = value;
        }
      }
      public Angle AimingVelocityMaximum
      {
        get
        {
          return this._aimingVelocityMaximum;
        }
        set
        {
          this._aimingVelocityMaximum = value;
        }
      }
      public Angle AimingAccelerationMaximum
      {
        get
        {
          return this._aimingAccelerationMaximum;
        }
        set
        {
          this._aimingAccelerationMaximum = value;
        }
      }
      public RealFraction CasualAimingModifier
      {
        get
        {
          return this._casualAimingModifier;
        }
        set
        {
          this._casualAimingModifier = value;
        }
      }
      public Angle LookingVelocityMaximum
      {
        get
        {
          return this._lookingVelocityMaximum;
        }
        set
        {
          this._lookingVelocityMaximum = value;
        }
      }
      public Angle LookingAccelerationMaximum
      {
        get
        {
          return this._lookingAccelerationMaximum;
        }
        set
        {
          this._lookingAccelerationMaximum = value;
        }
      }
      public Real AIVehicleRadius
      {
        get
        {
          return this._aIVehicleRadius;
        }
        set
        {
          this._aIVehicleRadius = value;
        }
      }
      public Real AIDangerRadius
      {
        get
        {
          return this._aIDangerRadius;
        }
        set
        {
          this._aIDangerRadius = value;
        }
      }
      public TagReference MeleeDamage
      {
        get
        {
          return this._meleeDamage;
        }
        set
        {
          this._meleeDamage = value;
        }
      }
      public Enum MotionSensorBlipSize
      {
        get
        {
          return this._motionSensorBlipSize;
        }
        set
        {
          this._motionSensorBlipSize = value;
        }
      }
      public Real GrenadeVelocity
      {
        get
        {
          return this._grenadeVelocity;
        }
        set
        {
          this._grenadeVelocity = value;
        }
      }
      public Enum GrenadeType
      {
        get
        {
          return this._grenadeType;
        }
        set
        {
          this._grenadeType = value;
        }
      }
      public ShortInteger GrenadeCount
      {
        get
        {
          return this._grenadeCount;
        }
        set
        {
          this._grenadeCount = value;
        }
      }
      public virtual void Read(BinaryReader reader)
      {
        _flags.Read(reader);
        _defaultTeam.Read(reader);
        _constantSoundVolume.Read(reader);
        _riderDamageFraction.Read(reader);
        _integratedLightToggle.Read(reader);
        _aIn.Read(reader);
        _bIn.Read(reader);
        _cIn.Read(reader);
        _dIn.Read(reader);
        _cameraFieldOfView.Read(reader);
        _cameraStiffness.Read(reader);
        _cameraMarkerName.Read(reader);
        _cameraSubmergedMarkerName.Read(reader);
        _pitchAut.Read(reader);
        _pitchRange.Read(reader);
        _cameraTracks.Read(reader);
        _seatAccelerationScale.Read(reader);
        _unnamed.Read(reader);
        _softPingThreshold.Read(reader);
        _softPingInterruptTime.Read(reader);
        _hardPingThreshold.Read(reader);
        _hardPingInterruptTime.Read(reader);
        _hardDeathThreshold.Read(reader);
        _feignDeathThreshold.Read(reader);
        _feignDeathTime.Read(reader);
        _distanceOfEvadeAnim.Read(reader);
        _distanceOfDiveAnim.Read(reader);
        _unnamed2.Read(reader);
        _stunnedMovementThreshold.Read(reader);
        _feignDeathChance.Read(reader);
        _feignRepeatChance.Read(reader);
        _spawnedActor.Read(reader);
        _spawnedActorCount.Read(reader);
        _spawnedVelocity.Read(reader);
        _aimingVelocityMaximum.Read(reader);
        _aimingAccelerationMaximum.Read(reader);
        _casualAimingModifier.Read(reader);
        _lookingVelocityMaximum.Read(reader);
        _lookingAccelerationMaximum.Read(reader);
        _unnamed3.Read(reader);
        _aIVehicleRadius.Read(reader);
        _aIDangerRadius.Read(reader);
        _meleeDamage.Read(reader);
        _motionSensorBlipSize.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _nEWHUDINTERFACES.Read(reader);
        _dialogueVariants.Read(reader);
        _grenadeVelocity.Read(reader);
        _grenadeType.Read(reader);
        _grenadeCount.Read(reader);
        _unnamed6.Read(reader);
        _poweredSeats.Read(reader);
        _weapons.Read(reader);
        _seats.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader)
      {
        int x = 0;
        _integratedLightToggle.ReadString(reader);
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1))
        {
          CameraTracks.Add(new UnitCameraTrackBlock());
          CameraTracks[x].Read(reader);
        }
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1))
        {
          CameraTracks[x].ReadChildData(reader);
        }
        _spawnedActor.ReadString(reader);
        _meleeDamage.ReadString(reader);
        for (x = 0; (x < _nEWHUDINTERFACES.Count); x = (x + 1))
        {
          NEWHUDINTERFACES.Add(new UnitHudReferenceBlock());
          NEWHUDINTERFACES[x].Read(reader);
        }
        for (x = 0; (x < _nEWHUDINTERFACES.Count); x = (x + 1))
        {
          NEWHUDINTERFACES[x].ReadChildData(reader);
        }
        for (x = 0; (x < _dialogueVariants.Count); x = (x + 1))
        {
          DialogueVariants.Add(new DialogueVariantBlock());
          DialogueVariants[x].Read(reader);
        }
        for (x = 0; (x < _dialogueVariants.Count); x = (x + 1))
        {
          DialogueVariants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _poweredSeats.Count); x = (x + 1))
        {
          PoweredSeats.Add(new PoweredSeatBlock());
          PoweredSeats[x].Read(reader);
        }
        for (x = 0; (x < _poweredSeats.Count); x = (x + 1))
        {
          PoweredSeats[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1))
        {
          Weapons.Add(new UnitWeaponBlock());
          Weapons[x].Read(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1))
        {
          Weapons[x].ReadChildData(reader);
        }
        for (x = 0; (x < _seats.Count); x = (x + 1))
        {
          Seats.Add(new UnitSeatBlock());
          Seats[x].Read(reader);
        }
        for (x = 0; (x < _seats.Count); x = (x + 1))
        {
          Seats[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw)
      {
        _flags.Write(bw);
        _defaultTeam.Write(bw);
        _constantSoundVolume.Write(bw);
        _riderDamageFraction.Write(bw);
        _integratedLightToggle.Write(bw);
        _aIn.Write(bw);
        _bIn.Write(bw);
        _cIn.Write(bw);
        _dIn.Write(bw);
        _cameraFieldOfView.Write(bw);
        _cameraStiffness.Write(bw);
        _cameraMarkerName.Write(bw);
        _cameraSubmergedMarkerName.Write(bw);
        _pitchAut.Write(bw);
        _pitchRange.Write(bw);
        _cameraTracks.Count = CameraTracks.Count;
        _cameraTracks.Write(bw);
        _seatAccelerationScale.Write(bw);
        _unnamed.Write(bw);
        _softPingThreshold.Write(bw);
        _softPingInterruptTime.Write(bw);
        _hardPingThreshold.Write(bw);
        _hardPingInterruptTime.Write(bw);
        _hardDeathThreshold.Write(bw);
        _feignDeathThreshold.Write(bw);
        _feignDeathTime.Write(bw);
        _distanceOfEvadeAnim.Write(bw);
        _distanceOfDiveAnim.Write(bw);
        _unnamed2.Write(bw);
        _stunnedMovementThreshold.Write(bw);
        _feignDeathChance.Write(bw);
        _feignRepeatChance.Write(bw);
        _spawnedActor.Write(bw);
        _spawnedActorCount.Write(bw);
        _spawnedVelocity.Write(bw);
        _aimingVelocityMaximum.Write(bw);
        _aimingAccelerationMaximum.Write(bw);
        _casualAimingModifier.Write(bw);
        _lookingVelocityMaximum.Write(bw);
        _lookingAccelerationMaximum.Write(bw);
        _unnamed3.Write(bw);
        _aIVehicleRadius.Write(bw);
        _aIDangerRadius.Write(bw);
        _meleeDamage.Write(bw);
        _motionSensorBlipSize.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _nEWHUDINTERFACES.Count = NEWHUDINTERFACES.Count;
        _nEWHUDINTERFACES.Write(bw);
        _dialogueVariants.Count = DialogueVariants.Count;
        _dialogueVariants.Write(bw);
        _grenadeVelocity.Write(bw);
        _grenadeType.Write(bw);
        _grenadeCount.Write(bw);
        _unnamed6.Write(bw);
        _poweredSeats.Count = PoweredSeats.Count;
        _poweredSeats.Write(bw);
        _weapons.Count = Weapons.Count;
        _weapons.Write(bw);
        _seats.Count = Seats.Count;
        _seats.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer)
      {
        int x = 0;
        _integratedLightToggle.WriteString(writer);
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1))
        {
          CameraTracks[x].Write(writer);
        }
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1))
        {
          CameraTracks[x].WriteChildData(writer);
        }
        _spawnedActor.WriteString(writer);
        _meleeDamage.WriteString(writer);
        for (x = 0; (x < _nEWHUDINTERFACES.Count); x = (x + 1))
        {
          NEWHUDINTERFACES[x].Write(writer);
        }
        for (x = 0; (x < _nEWHUDINTERFACES.Count); x = (x + 1))
        {
          NEWHUDINTERFACES[x].WriteChildData(writer);
        }
        for (x = 0; (x < _dialogueVariants.Count); x = (x + 1))
        {
          DialogueVariants[x].Write(writer);
        }
        for (x = 0; (x < _dialogueVariants.Count); x = (x + 1))
        {
          DialogueVariants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _poweredSeats.Count); x = (x + 1))
        {
          PoweredSeats[x].Write(writer);
        }
        for (x = 0; (x < _poweredSeats.Count); x = (x + 1))
        {
          PoweredSeats[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1))
        {
          Weapons[x].Write(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1))
        {
          Weapons[x].WriteChildData(writer);
        }
        for (x = 0; (x < _seats.Count); x = (x + 1))
        {
          Seats[x].Write(writer);
        }
        for (x = 0; (x < _seats.Count); x = (x + 1))
        {
          Seats[x].WriteChildData(writer);
        }
      }
    }
    public class UnitCameraTrackBlock : IBlock
    {
      private TagReference _track = new TagReference();
      private Pad _unnamed;
      public event System.EventHandler BlockNameChanged;
      public UnitCameraTrackBlock()
      {
        this._unnamed = new Pad(12);
      }
      public virtual string[] TagReferenceList
      {
        get
        {
          UniqueStringCollection references = new UniqueStringCollection();
          references.Add(_track.Value);
          return references.ToArray();
        }
      }
      public virtual string BlockName
      {
        get
        {
          return "";
        }
      }
      public TagReference Track
      {
        get
        {
          return this._track;
        }
        set
        {
          this._track = value;
        }
      }
      public virtual void Read(BinaryReader reader)
      {
        _track.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader)
      {
        _track.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw)
      {
        _track.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer)
      {
        _track.WriteString(writer);
      }
    }
    public class UnitHudReferenceBlock : IBlock
    {
      private TagReference _unitHudInterface = new TagReference();
      private Pad _unnamed;
      public event System.EventHandler BlockNameChanged;
      public UnitHudReferenceBlock()
      {
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList
      {
        get
        {
          UniqueStringCollection references = new UniqueStringCollection();
          references.Add(_unitHudInterface.Value);
          return references.ToArray();
        }
      }
      public virtual string BlockName
      {
        get
        {
          return "";
        }
      }
      public TagReference UnitHudInterface
      {
        get
        {
          return this._unitHudInterface;
        }
        set
        {
          this._unitHudInterface = value;
        }
      }
      public virtual void Read(BinaryReader reader)
      {
        _unitHudInterface.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader)
      {
        _unitHudInterface.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw)
      {
        _unitHudInterface.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer)
      {
        _unitHudInterface.WriteString(writer);
      }
    }
    public class DialogueVariantBlock : IBlock
    {
      private ShortInteger _variantNumber = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private TagReference _dialogue = new TagReference();
      public event System.EventHandler BlockNameChanged;
      public DialogueVariantBlock()
      {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(4);
      }
      public virtual string[] TagReferenceList
      {
        get
        {
          UniqueStringCollection references = new UniqueStringCollection();
          references.Add(_dialogue.Value);
          return references.ToArray();
        }
      }
      public virtual string BlockName
      {
        get
        {
          return "";
        }
      }
      public ShortInteger VariantNumber
      {
        get
        {
          return this._variantNumber;
        }
        set
        {
          this._variantNumber = value;
        }
      }
      public TagReference Dialogue
      {
        get
        {
          return this._dialogue;
        }
        set
        {
          this._dialogue = value;
        }
      }
      public virtual void Read(BinaryReader reader)
      {
        _variantNumber.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _dialogue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader)
      {
        _dialogue.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw)
      {
        _variantNumber.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _dialogue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer)
      {
        _dialogue.WriteString(writer);
      }
    }
    public class PoweredSeatBlock : IBlock
    {
      private Pad _unnamed;
      private Real _driverPowerupTime = new Real();
      private Real _driverPowerdownTime = new Real();
      private Pad _unnamed2;
      public event System.EventHandler BlockNameChanged;
      public PoweredSeatBlock()
      {
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(56);
      }
      public virtual string[] TagReferenceList
      {
        get
        {
          UniqueStringCollection references = new UniqueStringCollection();
          return references.ToArray();
        }
      }
      public virtual string BlockName
      {
        get
        {
          return "";
        }
      }
      public Real DriverPowerupTime
      {
        get
        {
          return this._driverPowerupTime;
        }
        set
        {
          this._driverPowerupTime = value;
        }
      }
      public Real DriverPowerdownTime
      {
        get
        {
          return this._driverPowerdownTime;
        }
        set
        {
          this._driverPowerdownTime = value;
        }
      }
      public virtual void Read(BinaryReader reader)
      {
        _unnamed.Read(reader);
        _driverPowerupTime.Read(reader);
        _driverPowerdownTime.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader)
      {
      }
      public virtual void Write(BinaryWriter bw)
      {
        _unnamed.Write(bw);
        _driverPowerupTime.Write(bw);
        _driverPowerdownTime.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer)
      {
      }
    }
    public class UnitWeaponBlock : IBlock
    {
      private TagReference _weapon = new TagReference();
      private Pad _unnamed;
      public event System.EventHandler BlockNameChanged;
      public UnitWeaponBlock()
      {
        if (this._weapon is System.ComponentModel.INotifyPropertyChanged)
          (this._weapon as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
          (System.ComponentModel.PropertyChangedEventHandler)delegate
          { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(20);
      }
      public virtual string[] TagReferenceList
      {
        get
        {
          UniqueStringCollection references = new UniqueStringCollection();
          references.Add(_weapon.Value);
          return references.ToArray();
        }
      }
      public virtual string BlockName
      {
        get
        {
          return _weapon.ToString();
        }
      }
      public TagReference Weapon
      {
        get
        {
          return this._weapon;
        }
        set
        {
          this._weapon = value;
        }
      }
      public virtual void Read(BinaryReader reader)
      {
        _weapon.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader)
      {
        _weapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw)
      {
        _weapon.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer)
      {
        _weapon.WriteString(writer);
      }
    }
    public class UnitSeatBlock : IBlock
    {
      private Flags _flags;
      private FixedLengthString _label = new FixedLengthString();
      private FixedLengthString _markerName = new FixedLengthString();
      private Pad _unnamed;
      private RealVector3D _accelerationScale = new RealVector3D();
      private Pad _unnamed2;
      private Real _yawRate = new Real();
      private Real _pitchRate = new Real();
      private FixedLengthString _cameraMarkerName = new FixedLengthString();
      private FixedLengthString _cameraSubmergedMarkerName = new FixedLengthString();
      private Angle _pitchAut = new Angle();
      private AngleBounds _pitchRange = new AngleBounds();
      private Block _cameraTracks = new Block();
      private Block _unitHudInterface = new Block();
      private Pad _unnamed3;
      private ShortInteger _hudTextMessageIndex = new ShortInteger();
      private Pad _unnamed4;
      private Angle _yawMinimum = new Angle();
      private Angle _yawMaximum = new Angle();
      private TagReference _buil = new TagReference();
      private Pad _unnamed5;
      public BlockCollection<UnitCameraTrackBlock> _cameraTracksList = new BlockCollection<UnitCameraTrackBlock>();
      public BlockCollection<UnitHudReferenceBlock> _unitHudInterfaceList = new BlockCollection<UnitHudReferenceBlock>();
      public event System.EventHandler BlockNameChanged;
      public UnitSeatBlock()
      {
        if (this._markerName is System.ComponentModel.INotifyPropertyChanged)
          (this._markerName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
          (System.ComponentModel.PropertyChangedEventHandler)delegate
          { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(32);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(20);
      }
      public BlockCollection<UnitCameraTrackBlock> CameraTracks
      {
        get
        {
          return this._cameraTracksList;
        }
      }
      public BlockCollection<UnitHudReferenceBlock> UnitHudInterface
      {
        get
        {
          return this._unitHudInterfaceList;
        }
      }
      public virtual string[] TagReferenceList
      {
        get
        {
          UniqueStringCollection references = new UniqueStringCollection();
          references.Add(_buil.Value);
          for (int x = 0; x < CameraTracks.BlockCount; x++)
          {
            IBlock block = CameraTracks.GetBlock(x);
            references.AddRange(block.TagReferenceList);
          }
          for (int x = 0; x < UnitHudInterface.BlockCount; x++)
          {
            IBlock block = UnitHudInterface.GetBlock(x);
            references.AddRange(block.TagReferenceList);
          }
          return references.ToArray();
        }
      }
      public virtual string BlockName
      {
        get
        {
          return _markerName.ToString();
        }
      }
      public Flags Flags
      {
        get
        {
          return this._flags;
        }
        set
        {
          this._flags = value;
        }
      }
      public FixedLengthString Label
      {
        get
        {
          return this._label;
        }
        set
        {
          this._label = value;
        }
      }
      public FixedLengthString MarkerName
      {
        get
        {
          return this._markerName;
        }
        set
        {
          this._markerName = value;
        }
      }
      public RealVector3D AccelerationScale
      {
        get
        {
          return this._accelerationScale;
        }
        set
        {
          this._accelerationScale = value;
        }
      }
      public Real YawRate
      {
        get
        {
          return this._yawRate;
        }
        set
        {
          this._yawRate = value;
        }
      }
      public Real PitchRate
      {
        get
        {
          return this._pitchRate;
        }
        set
        {
          this._pitchRate = value;
        }
      }
      public FixedLengthString CameraMarkerName
      {
        get
        {
          return this._cameraMarkerName;
        }
        set
        {
          this._cameraMarkerName = value;
        }
      }
      public FixedLengthString CameraSubmergedMarkerName
      {
        get
        {
          return this._cameraSubmergedMarkerName;
        }
        set
        {
          this._cameraSubmergedMarkerName = value;
        }
      }
      public Angle PitchAut
      {
        get
        {
          return this._pitchAut;
        }
        set
        {
          this._pitchAut = value;
        }
      }
      public AngleBounds PitchRange
      {
        get
        {
          return this._pitchRange;
        }
        set
        {
          this._pitchRange = value;
        }
      }
      public ShortInteger HudTextMessageIndex
      {
        get
        {
          return this._hudTextMessageIndex;
        }
        set
        {
          this._hudTextMessageIndex = value;
        }
      }
      public Angle YawMinimum
      {
        get
        {
          return this._yawMinimum;
        }
        set
        {
          this._yawMinimum = value;
        }
      }
      public Angle YawMaximum
      {
        get
        {
          return this._yawMaximum;
        }
        set
        {
          this._yawMaximum = value;
        }
      }
      public TagReference Buil
      {
        get
        {
          return this._buil;
        }
        set
        {
          this._buil = value;
        }
      }
      public virtual void Read(BinaryReader reader)
      {
        _flags.Read(reader);
        _label.Read(reader);
        _markerName.Read(reader);
        _unnamed.Read(reader);
        _accelerationScale.Read(reader);
        _unnamed2.Read(reader);
        _yawRate.Read(reader);
        _pitchRate.Read(reader);
        _cameraMarkerName.Read(reader);
        _cameraSubmergedMarkerName.Read(reader);
        _pitchAut.Read(reader);
        _pitchRange.Read(reader);
        _cameraTracks.Read(reader);
        _unitHudInterface.Read(reader);
        _unnamed3.Read(reader);
        _hudTextMessageIndex.Read(reader);
        _unnamed4.Read(reader);
        _yawMinimum.Read(reader);
        _yawMaximum.Read(reader);
        _buil.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader)
      {
        int x = 0;
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1))
        {
          CameraTracks.Add(new UnitCameraTrackBlock());
          CameraTracks[x].Read(reader);
        }
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1))
        {
          CameraTracks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unitHudInterface.Count); x = (x + 1))
        {
          UnitHudInterface.Add(new UnitHudReferenceBlock());
          UnitHudInterface[x].Read(reader);
        }
        for (x = 0; (x < _unitHudInterface.Count); x = (x + 1))
        {
          UnitHudInterface[x].ReadChildData(reader);
        }
        _buil.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw)
      {
        _flags.Write(bw);
        _label.Write(bw);
        _markerName.Write(bw);
        _unnamed.Write(bw);
        _accelerationScale.Write(bw);
        _unnamed2.Write(bw);
        _yawRate.Write(bw);
        _pitchRate.Write(bw);
        _cameraMarkerName.Write(bw);
        _cameraSubmergedMarkerName.Write(bw);
        _pitchAut.Write(bw);
        _pitchRange.Write(bw);
        _cameraTracks.Count = CameraTracks.Count;
        _cameraTracks.Write(bw);
        _unitHudInterface.Count = UnitHudInterface.Count;
        _unitHudInterface.Write(bw);
        _unnamed3.Write(bw);
        _hudTextMessageIndex.Write(bw);
        _unnamed4.Write(bw);
        _yawMinimum.Write(bw);
        _yawMaximum.Write(bw);
        _buil.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer)
      {
        int x = 0;
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1))
        {
          CameraTracks[x].Write(writer);
        }
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1))
        {
          CameraTracks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unitHudInterface.Count); x = (x + 1))
        {
          UnitHudInterface[x].Write(writer);
        }
        for (x = 0; (x < _unitHudInterface.Count); x = (x + 1))
        {
          UnitHudInterface[x].WriteChildData(writer);
        }
        _buil.WriteString(writer);
      }
    }
  }
}
