// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'actor'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class actor : Interfaces.Pool.Tag {
    private ActorBlock actorValues = new ActorBlock();
    public virtual ActorBlock ActorValues {
      get {
        return actorValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ActorValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "actor";
      }
    }
    #region Read/Write Methods
    public override int Load(byte[] metadata) {
      System.IO.BinaryReader reader = new System.IO.BinaryReader(new System.IO.MemoryStream(metadata));
Read(reader);
int position = (int)reader.BaseStream.Position;
ReadChildData(reader);
reader.Close();
      return position;
    }
    public override void Read(BinaryReader reader) {
actorValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
actorValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
actorValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
actorValues.WriteChildData(writer);
    }
    #endregion
    public class ActorBlock : IBlock {
      private Flags _flags;
      private Flags _moreFlags;
      private Pad _unnamed;
      private Enum _type = new Enum();
      private Pad _unnamed2;
      private Real _maxVisionDistance = new Real();
      private Angle _centralVisionAngle = new Angle();
      private Angle _maxVisionAngle = new Angle();
      private Pad _unnamed3;
      private Angle _peripheralVisionAngle = new Angle();
      private Real _peripheralDistance = new Real();
      private Pad _unnamed4;
      private RealVector3D _standingGunOffset = new RealVector3D();
      private RealVector3D _crouchingGunOffset = new RealVector3D();
      private Real _hearingDistance = new Real();
      private Real _noticeProjectileChance = new Real();
      private Real _noticeVehicleChance = new Real();
      private Pad _unnamed5;
      private Real _combatPerceptionTime = new Real();
      private Real _guardPerceptionTime = new Real();
      private Real _no = new Real();
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Real _diveIntoCoverChance = new Real();
      private Real _emergeFromCoverChance = new Real();
      private Real _diveFromGrenadeChance = new Real();
      private Real _pathfindingRadius = new Real();
      private Real _glassIgnoranceChance = new Real();
      private Real _stationaryMovementDist = new Real();
      private Real _fre = new Real();
      private Angle _beginMovingAngle = new Angle();
      private Pad _unnamed8;
      private RealEulerAngles2D _maximumAimingDeviation = new RealEulerAngles2D();
      private RealEulerAngles2D _maximumLookingDeviation = new RealEulerAngles2D();
      private Angle _noncombatLookDeltaL = new Angle();
      private Angle _noncombatLookDeltaR = new Angle();
      private Angle _combatLookDeltaL = new Angle();
      private Angle _combatLookDeltaR = new Angle();
      private RealEulerAngles2D _idleAimingRange = new RealEulerAngles2D();
      private RealEulerAngles2D _idleLookingRange = new RealEulerAngles2D();
      private RealBounds _eventLookTimeModifier = new RealBounds();
      private RealBounds _noncombatIdleFacing = new RealBounds();
      private RealBounds _noncombatIdleAiming = new RealBounds();
      private RealBounds _noncombatIdleLooking = new RealBounds();
      private RealBounds _guardIdleFacing = new RealBounds();
      private RealBounds _guardIdleAiming = new RealBounds();
      private RealBounds _guardIdleLooking = new RealBounds();
      private RealBounds _combatIdleFacing = new RealBounds();
      private RealBounds _combatIdleAiming = new RealBounds();
      private RealBounds _combatIdleLooking = new RealBounds();
      private Pad _unnamed9;
      private Pad _unnamed10;
      private TagReference _dONOTUSE = new TagReference();
      private Pad _unnamed11;
      private TagReference _dONOTUSE2 = new TagReference();
      private Enum _unreachableDangerTrigger = new Enum();
      private Enum _vehicleDangerTrigger = new Enum();
      private Enum _playerDangerTrigger = new Enum();
      private Pad _unnamed12;
      private RealBounds _dangerTriggerTime = new RealBounds();
      private ShortInteger _friendsKilledTrigger = new ShortInteger();
      private ShortInteger _friendsRetreatingTrigger = new ShortInteger();
      private Pad _unnamed13;
      private RealBounds _retreatTime = new RealBounds();
      private Pad _unnamed14;
      private RealBounds _coweringTime = new RealBounds();
      private Real _friendKilledPanicChance = new Real();
      private Enum _leaderType = new Enum();
      private Pad _unnamed15;
      private Real _leaderKilledPanicChance = new Real();
      private Real _panicDamageThreshold = new Real();
      private Real _surpriseDistance = new Real();
      private Pad _unnamed16;
      private RealBounds _hideBehindCoverTime = new RealBounds();
      private Real _hideTarge = new Real();
      private Real _hideShieldFraction = new Real();
      private Real _attackShieldFraction = new Real();
      private Real _pursueShieldFraction = new Real();
      private Pad _unnamed17;
      private Enum _defensiveCrouchType = new Enum();
      private Pad _unnamed18;
      private Real _attackingCrouchThreshold = new Real();
      private Real _defendingCrouchThreshold = new Real();
      private Real _minStandTime = new Real();
      private Real _minCrouchTime = new Real();
      private Real _defendingHideTimeModifier = new Real();
      private Real _attackingEvasionThreshold = new Real();
      private Real _defendingEvasionThreshold = new Real();
      private Real _evasionSee = new Real();
      private Real _evasionDelayTime = new Real();
      private Real _maxSee = new Real();
      private Real _coverDamageThreshold = new Real();
      private Real _stalkingDiscoveryTime = new Real();
      private Real _stalkingMaxDistance = new Real();
      private Angle _stationaryFacingAngle = new Angle();
      private Real _chang = new Real();
      private Pad _unnamed19;
      private RealBounds _uncoverDelayTime = new RealBounds();
      private RealBounds _targetSearchTime = new RealBounds();
      private RealBounds _pursui = new RealBounds();
      private ShortInteger _numPositionsCoord = new ShortInteger();
      private ShortInteger _numPositionsNormal = new ShortInteger();
      private Pad _unnamed20;
      private Real _meleeAttackDelay = new Real();
      private Real _meleeFudgeFactor = new Real();
      private Real _meleeChargeTime = new Real();
      private RealBounds _meleeLeapRange = new RealBounds();
      private Real _meleeLeapVelocity = new Real();
      private Real _meleeLeapChance = new Real();
      private Real _meleeLeapBallistic = new Real();
      private Real _berserkDamageAmount = new Real();
      private Real _berserkDamageThreshold = new Real();
      private Real _berserkProximity = new Real();
      private Real _suicideSensingDist = new Real();
      private Real _berserkGrenadeChance = new Real();
      private Pad _unnamed21;
      private RealBounds _guardPositionTime = new RealBounds();
      private RealBounds _combatPositionTime = new RealBounds();
      private Real _oldPositionAvoidDist = new Real();
      private Real _friendAvoidDist = new Real();
      private Pad _unnamed22;
      private RealBounds _noncombatIdleSpeechTime = new RealBounds();
      private RealBounds _combatIdleSpeechTime = new RealBounds();
      private Pad _unnamed23;
      private Pad _unnamed24;
      private TagReference _dONOTUSE3 = new TagReference();
      private Pad _unnamed25;
public event System.EventHandler BlockNameChanged;
      public ActorBlock() {
        this._flags = new Flags(4);
        this._moreFlags = new Flags(4);
        this._unnamed = new Pad(12);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(8);
        this._unnamed6 = new Pad(12);
        this._unnamed7 = new Pad(8);
        this._unnamed8 = new Pad(4);
        this._unnamed9 = new Pad(8);
        this._unnamed10 = new Pad(16);
        this._unnamed11 = new Pad(268);
        this._unnamed12 = new Pad(2);
        this._unnamed13 = new Pad(12);
        this._unnamed14 = new Pad(8);
        this._unnamed15 = new Pad(2);
        this._unnamed16 = new Pad(28);
        this._unnamed17 = new Pad(16);
        this._unnamed18 = new Pad(2);
        this._unnamed19 = new Pad(4);
        this._unnamed20 = new Pad(32);
        this._unnamed21 = new Pad(12);
        this._unnamed22 = new Pad(40);
        this._unnamed23 = new Pad(48);
        this._unnamed24 = new Pad(128);
        this._unnamed25 = new Pad(48);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_dONOTUSE.Value);
references.Add(_dONOTUSE2.Value);
references.Add(_dONOTUSE3.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Flags MoreFlags {
        get {
          return this._moreFlags;
        }
        set {
          this._moreFlags = value;
        }
      }
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public Real MaxVisionDistance {
        get {
          return this._maxVisionDistance;
        }
        set {
          this._maxVisionDistance = value;
        }
      }
      public Angle CentralVisionAngle {
        get {
          return this._centralVisionAngle;
        }
        set {
          this._centralVisionAngle = value;
        }
      }
      public Angle MaxVisionAngle {
        get {
          return this._maxVisionAngle;
        }
        set {
          this._maxVisionAngle = value;
        }
      }
      public Angle PeripheralVisionAngle {
        get {
          return this._peripheralVisionAngle;
        }
        set {
          this._peripheralVisionAngle = value;
        }
      }
      public Real PeripheralDistance {
        get {
          return this._peripheralDistance;
        }
        set {
          this._peripheralDistance = value;
        }
      }
      public RealVector3D StandingGunOffset {
        get {
          return this._standingGunOffset;
        }
        set {
          this._standingGunOffset = value;
        }
      }
      public RealVector3D CrouchingGunOffset {
        get {
          return this._crouchingGunOffset;
        }
        set {
          this._crouchingGunOffset = value;
        }
      }
      public Real HearingDistance {
        get {
          return this._hearingDistance;
        }
        set {
          this._hearingDistance = value;
        }
      }
      public Real NoticeProjectileChance {
        get {
          return this._noticeProjectileChance;
        }
        set {
          this._noticeProjectileChance = value;
        }
      }
      public Real NoticeVehicleChance {
        get {
          return this._noticeVehicleChance;
        }
        set {
          this._noticeVehicleChance = value;
        }
      }
      public Real CombatPerceptionTime {
        get {
          return this._combatPerceptionTime;
        }
        set {
          this._combatPerceptionTime = value;
        }
      }
      public Real GuardPerceptionTime {
        get {
          return this._guardPerceptionTime;
        }
        set {
          this._guardPerceptionTime = value;
        }
      }
      public Real No {
        get {
          return this._no;
        }
        set {
          this._no = value;
        }
      }
      public Real DiveIntoCoverChance {
        get {
          return this._diveIntoCoverChance;
        }
        set {
          this._diveIntoCoverChance = value;
        }
      }
      public Real EmergeFromCoverChance {
        get {
          return this._emergeFromCoverChance;
        }
        set {
          this._emergeFromCoverChance = value;
        }
      }
      public Real DiveFromGrenadeChance {
        get {
          return this._diveFromGrenadeChance;
        }
        set {
          this._diveFromGrenadeChance = value;
        }
      }
      public Real PathfindingRadius {
        get {
          return this._pathfindingRadius;
        }
        set {
          this._pathfindingRadius = value;
        }
      }
      public Real GlassIgnoranceChance {
        get {
          return this._glassIgnoranceChance;
        }
        set {
          this._glassIgnoranceChance = value;
        }
      }
      public Real StationaryMovementDist {
        get {
          return this._stationaryMovementDist;
        }
        set {
          this._stationaryMovementDist = value;
        }
      }
      public Real Fre {
        get {
          return this._fre;
        }
        set {
          this._fre = value;
        }
      }
      public Angle BeginMovingAngle {
        get {
          return this._beginMovingAngle;
        }
        set {
          this._beginMovingAngle = value;
        }
      }
      public RealEulerAngles2D MaximumAimingDeviation {
        get {
          return this._maximumAimingDeviation;
        }
        set {
          this._maximumAimingDeviation = value;
        }
      }
      public RealEulerAngles2D MaximumLookingDeviation {
        get {
          return this._maximumLookingDeviation;
        }
        set {
          this._maximumLookingDeviation = value;
        }
      }
      public Angle NoncombatLookDeltaL {
        get {
          return this._noncombatLookDeltaL;
        }
        set {
          this._noncombatLookDeltaL = value;
        }
      }
      public Angle NoncombatLookDeltaR {
        get {
          return this._noncombatLookDeltaR;
        }
        set {
          this._noncombatLookDeltaR = value;
        }
      }
      public Angle CombatLookDeltaL {
        get {
          return this._combatLookDeltaL;
        }
        set {
          this._combatLookDeltaL = value;
        }
      }
      public Angle CombatLookDeltaR {
        get {
          return this._combatLookDeltaR;
        }
        set {
          this._combatLookDeltaR = value;
        }
      }
      public RealEulerAngles2D IdleAimingRange {
        get {
          return this._idleAimingRange;
        }
        set {
          this._idleAimingRange = value;
        }
      }
      public RealEulerAngles2D IdleLookingRange {
        get {
          return this._idleLookingRange;
        }
        set {
          this._idleLookingRange = value;
        }
      }
      public RealBounds EventLookTimeModifier {
        get {
          return this._eventLookTimeModifier;
        }
        set {
          this._eventLookTimeModifier = value;
        }
      }
      public RealBounds NoncombatIdleFacing {
        get {
          return this._noncombatIdleFacing;
        }
        set {
          this._noncombatIdleFacing = value;
        }
      }
      public RealBounds NoncombatIdleAiming {
        get {
          return this._noncombatIdleAiming;
        }
        set {
          this._noncombatIdleAiming = value;
        }
      }
      public RealBounds NoncombatIdleLooking {
        get {
          return this._noncombatIdleLooking;
        }
        set {
          this._noncombatIdleLooking = value;
        }
      }
      public RealBounds GuardIdleFacing {
        get {
          return this._guardIdleFacing;
        }
        set {
          this._guardIdleFacing = value;
        }
      }
      public RealBounds GuardIdleAiming {
        get {
          return this._guardIdleAiming;
        }
        set {
          this._guardIdleAiming = value;
        }
      }
      public RealBounds GuardIdleLooking {
        get {
          return this._guardIdleLooking;
        }
        set {
          this._guardIdleLooking = value;
        }
      }
      public RealBounds CombatIdleFacing {
        get {
          return this._combatIdleFacing;
        }
        set {
          this._combatIdleFacing = value;
        }
      }
      public RealBounds CombatIdleAiming {
        get {
          return this._combatIdleAiming;
        }
        set {
          this._combatIdleAiming = value;
        }
      }
      public RealBounds CombatIdleLooking {
        get {
          return this._combatIdleLooking;
        }
        set {
          this._combatIdleLooking = value;
        }
      }
      public TagReference DONOTUSE {
        get {
          return this._dONOTUSE;
        }
        set {
          this._dONOTUSE = value;
        }
      }
      public TagReference DONOTUSE2 {
        get {
          return this._dONOTUSE2;
        }
        set {
          this._dONOTUSE2 = value;
        }
      }
      public Enum UnreachableDangerTrigger {
        get {
          return this._unreachableDangerTrigger;
        }
        set {
          this._unreachableDangerTrigger = value;
        }
      }
      public Enum VehicleDangerTrigger {
        get {
          return this._vehicleDangerTrigger;
        }
        set {
          this._vehicleDangerTrigger = value;
        }
      }
      public Enum PlayerDangerTrigger {
        get {
          return this._playerDangerTrigger;
        }
        set {
          this._playerDangerTrigger = value;
        }
      }
      public RealBounds DangerTriggerTime {
        get {
          return this._dangerTriggerTime;
        }
        set {
          this._dangerTriggerTime = value;
        }
      }
      public ShortInteger FriendsKilledTrigger {
        get {
          return this._friendsKilledTrigger;
        }
        set {
          this._friendsKilledTrigger = value;
        }
      }
      public ShortInteger FriendsRetreatingTrigger {
        get {
          return this._friendsRetreatingTrigger;
        }
        set {
          this._friendsRetreatingTrigger = value;
        }
      }
      public RealBounds RetreatTime {
        get {
          return this._retreatTime;
        }
        set {
          this._retreatTime = value;
        }
      }
      public RealBounds CoweringTime {
        get {
          return this._coweringTime;
        }
        set {
          this._coweringTime = value;
        }
      }
      public Real FriendKilledPanicChance {
        get {
          return this._friendKilledPanicChance;
        }
        set {
          this._friendKilledPanicChance = value;
        }
      }
      public Enum LeaderType {
        get {
          return this._leaderType;
        }
        set {
          this._leaderType = value;
        }
      }
      public Real LeaderKilledPanicChance {
        get {
          return this._leaderKilledPanicChance;
        }
        set {
          this._leaderKilledPanicChance = value;
        }
      }
      public Real PanicDamageThreshold {
        get {
          return this._panicDamageThreshold;
        }
        set {
          this._panicDamageThreshold = value;
        }
      }
      public Real SurpriseDistance {
        get {
          return this._surpriseDistance;
        }
        set {
          this._surpriseDistance = value;
        }
      }
      public RealBounds HideBehindCoverTime {
        get {
          return this._hideBehindCoverTime;
        }
        set {
          this._hideBehindCoverTime = value;
        }
      }
      public Real HideTarge {
        get {
          return this._hideTarge;
        }
        set {
          this._hideTarge = value;
        }
      }
      public Real HideShieldFraction {
        get {
          return this._hideShieldFraction;
        }
        set {
          this._hideShieldFraction = value;
        }
      }
      public Real AttackShieldFraction {
        get {
          return this._attackShieldFraction;
        }
        set {
          this._attackShieldFraction = value;
        }
      }
      public Real PursueShieldFraction {
        get {
          return this._pursueShieldFraction;
        }
        set {
          this._pursueShieldFraction = value;
        }
      }
      public Enum DefensiveCrouchType {
        get {
          return this._defensiveCrouchType;
        }
        set {
          this._defensiveCrouchType = value;
        }
      }
      public Real AttackingCrouchThreshold {
        get {
          return this._attackingCrouchThreshold;
        }
        set {
          this._attackingCrouchThreshold = value;
        }
      }
      public Real DefendingCrouchThreshold {
        get {
          return this._defendingCrouchThreshold;
        }
        set {
          this._defendingCrouchThreshold = value;
        }
      }
      public Real MinStandTime {
        get {
          return this._minStandTime;
        }
        set {
          this._minStandTime = value;
        }
      }
      public Real MinCrouchTime {
        get {
          return this._minCrouchTime;
        }
        set {
          this._minCrouchTime = value;
        }
      }
      public Real DefendingHideTimeModifier {
        get {
          return this._defendingHideTimeModifier;
        }
        set {
          this._defendingHideTimeModifier = value;
        }
      }
      public Real AttackingEvasionThreshold {
        get {
          return this._attackingEvasionThreshold;
        }
        set {
          this._attackingEvasionThreshold = value;
        }
      }
      public Real DefendingEvasionThreshold {
        get {
          return this._defendingEvasionThreshold;
        }
        set {
          this._defendingEvasionThreshold = value;
        }
      }
      public Real EvasionSee {
        get {
          return this._evasionSee;
        }
        set {
          this._evasionSee = value;
        }
      }
      public Real EvasionDelayTime {
        get {
          return this._evasionDelayTime;
        }
        set {
          this._evasionDelayTime = value;
        }
      }
      public Real MaxSee {
        get {
          return this._maxSee;
        }
        set {
          this._maxSee = value;
        }
      }
      public Real CoverDamageThreshold {
        get {
          return this._coverDamageThreshold;
        }
        set {
          this._coverDamageThreshold = value;
        }
      }
      public Real StalkingDiscoveryTime {
        get {
          return this._stalkingDiscoveryTime;
        }
        set {
          this._stalkingDiscoveryTime = value;
        }
      }
      public Real StalkingMaxDistance {
        get {
          return this._stalkingMaxDistance;
        }
        set {
          this._stalkingMaxDistance = value;
        }
      }
      public Angle StationaryFacingAngle {
        get {
          return this._stationaryFacingAngle;
        }
        set {
          this._stationaryFacingAngle = value;
        }
      }
      public Real Chang {
        get {
          return this._chang;
        }
        set {
          this._chang = value;
        }
      }
      public RealBounds UncoverDelayTime {
        get {
          return this._uncoverDelayTime;
        }
        set {
          this._uncoverDelayTime = value;
        }
      }
      public RealBounds TargetSearchTime {
        get {
          return this._targetSearchTime;
        }
        set {
          this._targetSearchTime = value;
        }
      }
      public RealBounds Pursui {
        get {
          return this._pursui;
        }
        set {
          this._pursui = value;
        }
      }
      public ShortInteger NumPositionsCoord {
        get {
          return this._numPositionsCoord;
        }
        set {
          this._numPositionsCoord = value;
        }
      }
      public ShortInteger NumPositionsNormal {
        get {
          return this._numPositionsNormal;
        }
        set {
          this._numPositionsNormal = value;
        }
      }
      public Real MeleeAttackDelay {
        get {
          return this._meleeAttackDelay;
        }
        set {
          this._meleeAttackDelay = value;
        }
      }
      public Real MeleeFudgeFactor {
        get {
          return this._meleeFudgeFactor;
        }
        set {
          this._meleeFudgeFactor = value;
        }
      }
      public Real MeleeChargeTime {
        get {
          return this._meleeChargeTime;
        }
        set {
          this._meleeChargeTime = value;
        }
      }
      public RealBounds MeleeLeapRange {
        get {
          return this._meleeLeapRange;
        }
        set {
          this._meleeLeapRange = value;
        }
      }
      public Real MeleeLeapVelocity {
        get {
          return this._meleeLeapVelocity;
        }
        set {
          this._meleeLeapVelocity = value;
        }
      }
      public Real MeleeLeapChance {
        get {
          return this._meleeLeapChance;
        }
        set {
          this._meleeLeapChance = value;
        }
      }
      public Real MeleeLeapBallistic {
        get {
          return this._meleeLeapBallistic;
        }
        set {
          this._meleeLeapBallistic = value;
        }
      }
      public Real BerserkDamageAmount {
        get {
          return this._berserkDamageAmount;
        }
        set {
          this._berserkDamageAmount = value;
        }
      }
      public Real BerserkDamageThreshold {
        get {
          return this._berserkDamageThreshold;
        }
        set {
          this._berserkDamageThreshold = value;
        }
      }
      public Real BerserkProximity {
        get {
          return this._berserkProximity;
        }
        set {
          this._berserkProximity = value;
        }
      }
      public Real SuicideSensingDist {
        get {
          return this._suicideSensingDist;
        }
        set {
          this._suicideSensingDist = value;
        }
      }
      public Real BerserkGrenadeChance {
        get {
          return this._berserkGrenadeChance;
        }
        set {
          this._berserkGrenadeChance = value;
        }
      }
      public RealBounds GuardPositionTime {
        get {
          return this._guardPositionTime;
        }
        set {
          this._guardPositionTime = value;
        }
      }
      public RealBounds CombatPositionTime {
        get {
          return this._combatPositionTime;
        }
        set {
          this._combatPositionTime = value;
        }
      }
      public Real OldPositionAvoidDist {
        get {
          return this._oldPositionAvoidDist;
        }
        set {
          this._oldPositionAvoidDist = value;
        }
      }
      public Real FriendAvoidDist {
        get {
          return this._friendAvoidDist;
        }
        set {
          this._friendAvoidDist = value;
        }
      }
      public RealBounds NoncombatIdleSpeechTime {
        get {
          return this._noncombatIdleSpeechTime;
        }
        set {
          this._noncombatIdleSpeechTime = value;
        }
      }
      public RealBounds CombatIdleSpeechTime {
        get {
          return this._combatIdleSpeechTime;
        }
        set {
          this._combatIdleSpeechTime = value;
        }
      }
      public TagReference DONOTUSE3 {
        get {
          return this._dONOTUSE3;
        }
        set {
          this._dONOTUSE3 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _moreFlags.Read(reader);
        _unnamed.Read(reader);
        _type.Read(reader);
        _unnamed2.Read(reader);
        _maxVisionDistance.Read(reader);
        _centralVisionAngle.Read(reader);
        _maxVisionAngle.Read(reader);
        _unnamed3.Read(reader);
        _peripheralVisionAngle.Read(reader);
        _peripheralDistance.Read(reader);
        _unnamed4.Read(reader);
        _standingGunOffset.Read(reader);
        _crouchingGunOffset.Read(reader);
        _hearingDistance.Read(reader);
        _noticeProjectileChance.Read(reader);
        _noticeVehicleChance.Read(reader);
        _unnamed5.Read(reader);
        _combatPerceptionTime.Read(reader);
        _guardPerceptionTime.Read(reader);
        _no.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _diveIntoCoverChance.Read(reader);
        _emergeFromCoverChance.Read(reader);
        _diveFromGrenadeChance.Read(reader);
        _pathfindingRadius.Read(reader);
        _glassIgnoranceChance.Read(reader);
        _stationaryMovementDist.Read(reader);
        _fre.Read(reader);
        _beginMovingAngle.Read(reader);
        _unnamed8.Read(reader);
        _maximumAimingDeviation.Read(reader);
        _maximumLookingDeviation.Read(reader);
        _noncombatLookDeltaL.Read(reader);
        _noncombatLookDeltaR.Read(reader);
        _combatLookDeltaL.Read(reader);
        _combatLookDeltaR.Read(reader);
        _idleAimingRange.Read(reader);
        _idleLookingRange.Read(reader);
        _eventLookTimeModifier.Read(reader);
        _noncombatIdleFacing.Read(reader);
        _noncombatIdleAiming.Read(reader);
        _noncombatIdleLooking.Read(reader);
        _guardIdleFacing.Read(reader);
        _guardIdleAiming.Read(reader);
        _guardIdleLooking.Read(reader);
        _combatIdleFacing.Read(reader);
        _combatIdleAiming.Read(reader);
        _combatIdleLooking.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _dONOTUSE.Read(reader);
        _unnamed11.Read(reader);
        _dONOTUSE2.Read(reader);
        _unreachableDangerTrigger.Read(reader);
        _vehicleDangerTrigger.Read(reader);
        _playerDangerTrigger.Read(reader);
        _unnamed12.Read(reader);
        _dangerTriggerTime.Read(reader);
        _friendsKilledTrigger.Read(reader);
        _friendsRetreatingTrigger.Read(reader);
        _unnamed13.Read(reader);
        _retreatTime.Read(reader);
        _unnamed14.Read(reader);
        _coweringTime.Read(reader);
        _friendKilledPanicChance.Read(reader);
        _leaderType.Read(reader);
        _unnamed15.Read(reader);
        _leaderKilledPanicChance.Read(reader);
        _panicDamageThreshold.Read(reader);
        _surpriseDistance.Read(reader);
        _unnamed16.Read(reader);
        _hideBehindCoverTime.Read(reader);
        _hideTarge.Read(reader);
        _hideShieldFraction.Read(reader);
        _attackShieldFraction.Read(reader);
        _pursueShieldFraction.Read(reader);
        _unnamed17.Read(reader);
        _defensiveCrouchType.Read(reader);
        _unnamed18.Read(reader);
        _attackingCrouchThreshold.Read(reader);
        _defendingCrouchThreshold.Read(reader);
        _minStandTime.Read(reader);
        _minCrouchTime.Read(reader);
        _defendingHideTimeModifier.Read(reader);
        _attackingEvasionThreshold.Read(reader);
        _defendingEvasionThreshold.Read(reader);
        _evasionSee.Read(reader);
        _evasionDelayTime.Read(reader);
        _maxSee.Read(reader);
        _coverDamageThreshold.Read(reader);
        _stalkingDiscoveryTime.Read(reader);
        _stalkingMaxDistance.Read(reader);
        _stationaryFacingAngle.Read(reader);
        _chang.Read(reader);
        _unnamed19.Read(reader);
        _uncoverDelayTime.Read(reader);
        _targetSearchTime.Read(reader);
        _pursui.Read(reader);
        _numPositionsCoord.Read(reader);
        _numPositionsNormal.Read(reader);
        _unnamed20.Read(reader);
        _meleeAttackDelay.Read(reader);
        _meleeFudgeFactor.Read(reader);
        _meleeChargeTime.Read(reader);
        _meleeLeapRange.Read(reader);
        _meleeLeapVelocity.Read(reader);
        _meleeLeapChance.Read(reader);
        _meleeLeapBallistic.Read(reader);
        _berserkDamageAmount.Read(reader);
        _berserkDamageThreshold.Read(reader);
        _berserkProximity.Read(reader);
        _suicideSensingDist.Read(reader);
        _berserkGrenadeChance.Read(reader);
        _unnamed21.Read(reader);
        _guardPositionTime.Read(reader);
        _combatPositionTime.Read(reader);
        _oldPositionAvoidDist.Read(reader);
        _friendAvoidDist.Read(reader);
        _unnamed22.Read(reader);
        _noncombatIdleSpeechTime.Read(reader);
        _combatIdleSpeechTime.Read(reader);
        _unnamed23.Read(reader);
        _unnamed24.Read(reader);
        _dONOTUSE3.Read(reader);
        _unnamed25.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _dONOTUSE.ReadString(reader);
        _dONOTUSE2.ReadString(reader);
        _dONOTUSE3.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _moreFlags.Write(bw);
        _unnamed.Write(bw);
        _type.Write(bw);
        _unnamed2.Write(bw);
        _maxVisionDistance.Write(bw);
        _centralVisionAngle.Write(bw);
        _maxVisionAngle.Write(bw);
        _unnamed3.Write(bw);
        _peripheralVisionAngle.Write(bw);
        _peripheralDistance.Write(bw);
        _unnamed4.Write(bw);
        _standingGunOffset.Write(bw);
        _crouchingGunOffset.Write(bw);
        _hearingDistance.Write(bw);
        _noticeProjectileChance.Write(bw);
        _noticeVehicleChance.Write(bw);
        _unnamed5.Write(bw);
        _combatPerceptionTime.Write(bw);
        _guardPerceptionTime.Write(bw);
        _no.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _diveIntoCoverChance.Write(bw);
        _emergeFromCoverChance.Write(bw);
        _diveFromGrenadeChance.Write(bw);
        _pathfindingRadius.Write(bw);
        _glassIgnoranceChance.Write(bw);
        _stationaryMovementDist.Write(bw);
        _fre.Write(bw);
        _beginMovingAngle.Write(bw);
        _unnamed8.Write(bw);
        _maximumAimingDeviation.Write(bw);
        _maximumLookingDeviation.Write(bw);
        _noncombatLookDeltaL.Write(bw);
        _noncombatLookDeltaR.Write(bw);
        _combatLookDeltaL.Write(bw);
        _combatLookDeltaR.Write(bw);
        _idleAimingRange.Write(bw);
        _idleLookingRange.Write(bw);
        _eventLookTimeModifier.Write(bw);
        _noncombatIdleFacing.Write(bw);
        _noncombatIdleAiming.Write(bw);
        _noncombatIdleLooking.Write(bw);
        _guardIdleFacing.Write(bw);
        _guardIdleAiming.Write(bw);
        _guardIdleLooking.Write(bw);
        _combatIdleFacing.Write(bw);
        _combatIdleAiming.Write(bw);
        _combatIdleLooking.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _dONOTUSE.Write(bw);
        _unnamed11.Write(bw);
        _dONOTUSE2.Write(bw);
        _unreachableDangerTrigger.Write(bw);
        _vehicleDangerTrigger.Write(bw);
        _playerDangerTrigger.Write(bw);
        _unnamed12.Write(bw);
        _dangerTriggerTime.Write(bw);
        _friendsKilledTrigger.Write(bw);
        _friendsRetreatingTrigger.Write(bw);
        _unnamed13.Write(bw);
        _retreatTime.Write(bw);
        _unnamed14.Write(bw);
        _coweringTime.Write(bw);
        _friendKilledPanicChance.Write(bw);
        _leaderType.Write(bw);
        _unnamed15.Write(bw);
        _leaderKilledPanicChance.Write(bw);
        _panicDamageThreshold.Write(bw);
        _surpriseDistance.Write(bw);
        _unnamed16.Write(bw);
        _hideBehindCoverTime.Write(bw);
        _hideTarge.Write(bw);
        _hideShieldFraction.Write(bw);
        _attackShieldFraction.Write(bw);
        _pursueShieldFraction.Write(bw);
        _unnamed17.Write(bw);
        _defensiveCrouchType.Write(bw);
        _unnamed18.Write(bw);
        _attackingCrouchThreshold.Write(bw);
        _defendingCrouchThreshold.Write(bw);
        _minStandTime.Write(bw);
        _minCrouchTime.Write(bw);
        _defendingHideTimeModifier.Write(bw);
        _attackingEvasionThreshold.Write(bw);
        _defendingEvasionThreshold.Write(bw);
        _evasionSee.Write(bw);
        _evasionDelayTime.Write(bw);
        _maxSee.Write(bw);
        _coverDamageThreshold.Write(bw);
        _stalkingDiscoveryTime.Write(bw);
        _stalkingMaxDistance.Write(bw);
        _stationaryFacingAngle.Write(bw);
        _chang.Write(bw);
        _unnamed19.Write(bw);
        _uncoverDelayTime.Write(bw);
        _targetSearchTime.Write(bw);
        _pursui.Write(bw);
        _numPositionsCoord.Write(bw);
        _numPositionsNormal.Write(bw);
        _unnamed20.Write(bw);
        _meleeAttackDelay.Write(bw);
        _meleeFudgeFactor.Write(bw);
        _meleeChargeTime.Write(bw);
        _meleeLeapRange.Write(bw);
        _meleeLeapVelocity.Write(bw);
        _meleeLeapChance.Write(bw);
        _meleeLeapBallistic.Write(bw);
        _berserkDamageAmount.Write(bw);
        _berserkDamageThreshold.Write(bw);
        _berserkProximity.Write(bw);
        _suicideSensingDist.Write(bw);
        _berserkGrenadeChance.Write(bw);
        _unnamed21.Write(bw);
        _guardPositionTime.Write(bw);
        _combatPositionTime.Write(bw);
        _oldPositionAvoidDist.Write(bw);
        _friendAvoidDist.Write(bw);
        _unnamed22.Write(bw);
        _noncombatIdleSpeechTime.Write(bw);
        _combatIdleSpeechTime.Write(bw);
        _unnamed23.Write(bw);
        _unnamed24.Write(bw);
        _dONOTUSE3.Write(bw);
        _unnamed25.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _dONOTUSE.WriteString(writer);
        _dONOTUSE2.WriteString(writer);
        _dONOTUSE3.WriteString(writer);
      }
    }
  }
}
