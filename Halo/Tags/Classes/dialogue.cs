// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'dialogue'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class dialogue : Interfaces.Pool.Tag {
    private DialogueBlock dialogueValues = new DialogueBlock();
    public virtual DialogueBlock DialogueValues {
      get {
        return dialogueValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(DialogueValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "dialogue";
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
dialogueValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
dialogueValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
dialogueValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
dialogueValues.WriteChildData(writer);
    }
    #endregion
    public class DialogueBlock : IBlock {
      private Skip _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private TagReference _idleNoncombat = new TagReference();
      private TagReference _idleCombat = new TagReference();
      private TagReference _idleFlee = new TagReference();
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Pad _unnamed6;
      private TagReference _painBodyMinor = new TagReference();
      private TagReference _painBodyMajor = new TagReference();
      private TagReference _painShield = new TagReference();
      private TagReference _painFalling = new TagReference();
      private TagReference _screamFear = new TagReference();
      private TagReference _screamPain = new TagReference();
      private TagReference _maimedLimb = new TagReference();
      private TagReference _maimedHead = new TagReference();
      private TagReference _deathQuiet = new TagReference();
      private TagReference _deathViolent = new TagReference();
      private TagReference _deathFalling = new TagReference();
      private TagReference _deathAgonizing = new TagReference();
      private TagReference _deathInstant = new TagReference();
      private TagReference _deathFlying = new TagReference();
      private Pad _unnamed7;
      private TagReference _damagedFriend = new TagReference();
      private TagReference _damagedFriendPlayer = new TagReference();
      private TagReference _damagedEnemy = new TagReference();
      private TagReference _damagedEnemyCm = new TagReference();
      private Pad _unnamed8;
      private Pad _unnamed9;
      private Pad _unnamed10;
      private Pad _unnamed11;
      private TagReference _hurtFriend = new TagReference();
      private TagReference _hurtFriendRe = new TagReference();
      private TagReference _hurtFriendPlayer = new TagReference();
      private TagReference _hurtEnemy = new TagReference();
      private TagReference _hurtEnemyRe = new TagReference();
      private TagReference _hurtEnemyCm = new TagReference();
      private TagReference _hurtEnemyBullet = new TagReference();
      private TagReference _hurtEnemyNeedler = new TagReference();
      private TagReference _hurtEnemyPlasma = new TagReference();
      private TagReference _hurtEnemySniper = new TagReference();
      private TagReference _hurtEnemyGrenade = new TagReference();
      private TagReference _hurtEnemyExplosion = new TagReference();
      private TagReference _hurtEnemyMelee = new TagReference();
      private TagReference _hurtEnemyFlame = new TagReference();
      private TagReference _hurtEnemyShotgun = new TagReference();
      private TagReference _hurtEnemyVehicle = new TagReference();
      private TagReference _hurtEnemyMountedweapon = new TagReference();
      private Pad _unnamed12;
      private Pad _unnamed13;
      private Pad _unnamed14;
      private TagReference _killedFriend = new TagReference();
      private TagReference _killedFriendCm = new TagReference();
      private TagReference _killedFriendPlayer = new TagReference();
      private TagReference _killedFriendPlayerCm = new TagReference();
      private TagReference _killedEnemy = new TagReference();
      private TagReference _killedEnemyCm = new TagReference();
      private TagReference _killedEnemyPlayer = new TagReference();
      private TagReference _killedEnemyPlayerCm = new TagReference();
      private TagReference _killedEnemyCovenant = new TagReference();
      private TagReference _killedEnemyCovenantCm = new TagReference();
      private TagReference _killedEnemyFloodcombat = new TagReference();
      private TagReference _killedEnemyFloodcombatCm = new TagReference();
      private TagReference _killedEnemyFloodcarrier = new TagReference();
      private TagReference _killedEnemyFloodcarrierCm = new TagReference();
      private TagReference _killedEnemySentinel = new TagReference();
      private TagReference _killedEnemySentinelCm = new TagReference();
      private TagReference _killedEnemyBullet = new TagReference();
      private TagReference _killedEnemyNeedler = new TagReference();
      private TagReference _killedEnemyPlasma = new TagReference();
      private TagReference _killedEnemySniper = new TagReference();
      private TagReference _killedEnemyGrenade = new TagReference();
      private TagReference _killedEnemyExplosion = new TagReference();
      private TagReference _killedEnemyMelee = new TagReference();
      private TagReference _killedEnemyFlame = new TagReference();
      private TagReference _killedEnemyShotgun = new TagReference();
      private TagReference _killedEnemyVehicle = new TagReference();
      private TagReference _killedEnemyMountedweapon = new TagReference();
      private TagReference _killingSpree = new TagReference();
      private Pad _unnamed15;
      private Pad _unnamed16;
      private Pad _unnamed17;
      private TagReference _playerKillCm = new TagReference();
      private TagReference _playerKillBulletCm = new TagReference();
      private TagReference _playerKillNeedlerCm = new TagReference();
      private TagReference _playerKillPlasmaCm = new TagReference();
      private TagReference _playerKillSniperCm = new TagReference();
      private TagReference _anyoneKillGrenadeCm = new TagReference();
      private TagReference _playerKillExplosionCm = new TagReference();
      private TagReference _playerKillMeleeCm = new TagReference();
      private TagReference _playerKillFlameCm = new TagReference();
      private TagReference _playerKillShotgunCm = new TagReference();
      private TagReference _playerKillVehicleCm = new TagReference();
      private TagReference _playerKillMountedweaponCm = new TagReference();
      private TagReference _playerKilllingSpreeCm = new TagReference();
      private Pad _unnamed18;
      private Pad _unnamed19;
      private Pad _unnamed20;
      private TagReference _friendDied = new TagReference();
      private TagReference _friendPlayerDied = new TagReference();
      private TagReference _friendKilledByFriend = new TagReference();
      private TagReference _friendKilledByFriendlyPlayer = new TagReference();
      private TagReference _friendKilledByEnemy = new TagReference();
      private TagReference _friendKilledByEnemyPlayer = new TagReference();
      private TagReference _friendKilledByCovenant = new TagReference();
      private TagReference _friendKilledByFlood = new TagReference();
      private TagReference _friendKilledBySentinel = new TagReference();
      private TagReference _friendBetrayed = new TagReference();
      private Pad _unnamed21;
      private Pad _unnamed22;
      private TagReference _newCombatAlone = new TagReference();
      private TagReference _newEnemyRecentCombat = new TagReference();
      private TagReference _oldEnemySighted = new TagReference();
      private TagReference _unexpectedEnemy = new TagReference();
      private TagReference _deadFriendFound = new TagReference();
      private TagReference _allianceBroken = new TagReference();
      private TagReference _allianceReformed = new TagReference();
      private TagReference _grenadeThrowing = new TagReference();
      private TagReference _grenadeSighted = new TagReference();
      private TagReference _grenadeStartle = new TagReference();
      private TagReference _grenadeDangerEnemy = new TagReference();
      private TagReference _grenadeDangerSelf = new TagReference();
      private TagReference _grenadeDangerFriend = new TagReference();
      private Pad _unnamed23;
      private Pad _unnamed24;
      private TagReference _newCombatGroupRe = new TagReference();
      private TagReference _newCombatNearbyRe = new TagReference();
      private TagReference _alertFriend = new TagReference();
      private TagReference _alertFriendRe = new TagReference();
      private TagReference _alertLostContact = new TagReference();
      private TagReference _alertLostContactRe = new TagReference();
      private TagReference _blocked = new TagReference();
      private TagReference _blockedRe = new TagReference();
      private TagReference _searchStart = new TagReference();
      private TagReference _searchQuery = new TagReference();
      private TagReference _searchQueryRe = new TagReference();
      private TagReference _searchReport = new TagReference();
      private TagReference _searchAbandon = new TagReference();
      private TagReference _searchGroupAbandon = new TagReference();
      private TagReference _groupUncover = new TagReference();
      private TagReference _groupUncoverRe = new TagReference();
      private TagReference _advance = new TagReference();
      private TagReference _advanceRe = new TagReference();
      private TagReference _retreat = new TagReference();
      private TagReference _retreatRe = new TagReference();
      private TagReference _cover = new TagReference();
      private Pad _unnamed25;
      private Pad _unnamed26;
      private Pad _unnamed27;
      private Pad _unnamed28;
      private TagReference _sightedFriendPlayer = new TagReference();
      private TagReference _shooting = new TagReference();
      private TagReference _shootingVehicle = new TagReference();
      private TagReference _shootingBerserk = new TagReference();
      private TagReference _shootingGroup = new TagReference();
      private TagReference _shootingTraitor = new TagReference();
      private TagReference _taunt = new TagReference();
      private TagReference _tauntRe = new TagReference();
      private TagReference _flee = new TagReference();
      private TagReference _fleeRe = new TagReference();
      private TagReference _fleeLeaderDied = new TagReference();
      private TagReference _attemptedFlee = new TagReference();
      private TagReference _attemptedFleeRe = new TagReference();
      private TagReference _lostContact = new TagReference();
      private TagReference _hidingFinished = new TagReference();
      private TagReference _vehicleEntry = new TagReference();
      private TagReference _vehicleExit = new TagReference();
      private TagReference _vehicleWoohoo = new TagReference();
      private TagReference _vehicleScared = new TagReference();
      private TagReference _vehicleCollision = new TagReference();
      private TagReference _partiallySighted = new TagReference();
      private TagReference _nothingThere = new TagReference();
      private TagReference _pleading = new TagReference();
      private Pad _unnamed29;
      private Pad _unnamed30;
      private Pad _unnamed31;
      private Pad _unnamed32;
      private Pad _unnamed33;
      private Pad _unnamed34;
      private TagReference _surprise = new TagReference();
      private TagReference _berserk = new TagReference();
      private TagReference _meleeAttack = new TagReference();
      private TagReference _dive = new TagReference();
      private TagReference _uncoverExclamation = new TagReference();
      private TagReference _leapAttack = new TagReference();
      private TagReference _resurrection = new TagReference();
      private Pad _unnamed35;
      private Pad _unnamed36;
      private Pad _unnamed37;
      private Pad _unnamed38;
      private TagReference _celebration = new TagReference();
      private TagReference _checkBodyEnemy = new TagReference();
      private TagReference _checkBodyFriend = new TagReference();
      private TagReference _shootingDeadEnemy = new TagReference();
      private TagReference _shootingDeadEnemyPlayer = new TagReference();
      private Pad _unnamed39;
      private Pad _unnamed40;
      private Pad _unnamed41;
      private Pad _unnamed42;
      private TagReference _alone = new TagReference();
      private TagReference _unscathed = new TagReference();
      private TagReference _seriouslyWounded = new TagReference();
      private TagReference _seriouslyWoundedRe = new TagReference();
      private TagReference _massacre = new TagReference();
      private TagReference _massacreRe = new TagReference();
      private TagReference _rout = new TagReference();
      private TagReference _routRe = new TagReference();
      private Pad _unnamed43;
      private Pad _unnamed44;
      private Pad _unnamed45;
      private Pad _unnamed46;
      private Pad _unnamed47;
public event System.EventHandler BlockNameChanged;
      public DialogueBlock() {
        this._unnamed = new Skip(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(16);
        this._unnamed5 = new Pad(16);
        this._unnamed6 = new Pad(16);
        this._unnamed7 = new Pad(16);
        this._unnamed8 = new Pad(16);
        this._unnamed9 = new Pad(16);
        this._unnamed10 = new Pad(16);
        this._unnamed11 = new Pad(16);
        this._unnamed12 = new Pad(16);
        this._unnamed13 = new Pad(16);
        this._unnamed14 = new Pad(16);
        this._unnamed15 = new Pad(16);
        this._unnamed16 = new Pad(16);
        this._unnamed17 = new Pad(16);
        this._unnamed18 = new Pad(16);
        this._unnamed19 = new Pad(16);
        this._unnamed20 = new Pad(16);
        this._unnamed21 = new Pad(16);
        this._unnamed22 = new Pad(16);
        this._unnamed23 = new Pad(16);
        this._unnamed24 = new Pad(16);
        this._unnamed25 = new Pad(16);
        this._unnamed26 = new Pad(16);
        this._unnamed27 = new Pad(16);
        this._unnamed28 = new Pad(16);
        this._unnamed29 = new Pad(16);
        this._unnamed30 = new Pad(16);
        this._unnamed31 = new Pad(16);
        this._unnamed32 = new Pad(16);
        this._unnamed33 = new Pad(16);
        this._unnamed34 = new Pad(16);
        this._unnamed35 = new Pad(16);
        this._unnamed36 = new Pad(16);
        this._unnamed37 = new Pad(16);
        this._unnamed38 = new Pad(16);
        this._unnamed39 = new Pad(16);
        this._unnamed40 = new Pad(16);
        this._unnamed41 = new Pad(16);
        this._unnamed42 = new Pad(16);
        this._unnamed43 = new Pad(16);
        this._unnamed44 = new Pad(16);
        this._unnamed45 = new Pad(16);
        this._unnamed46 = new Pad(16);
        this._unnamed47 = new Pad(752);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_idleNoncombat.Value);
references.Add(_idleCombat.Value);
references.Add(_idleFlee.Value);
references.Add(_painBodyMinor.Value);
references.Add(_painBodyMajor.Value);
references.Add(_painShield.Value);
references.Add(_painFalling.Value);
references.Add(_screamFear.Value);
references.Add(_screamPain.Value);
references.Add(_maimedLimb.Value);
references.Add(_maimedHead.Value);
references.Add(_deathQuiet.Value);
references.Add(_deathViolent.Value);
references.Add(_deathFalling.Value);
references.Add(_deathAgonizing.Value);
references.Add(_deathInstant.Value);
references.Add(_deathFlying.Value);
references.Add(_damagedFriend.Value);
references.Add(_damagedFriendPlayer.Value);
references.Add(_damagedEnemy.Value);
references.Add(_damagedEnemyCm.Value);
references.Add(_hurtFriend.Value);
references.Add(_hurtFriendRe.Value);
references.Add(_hurtFriendPlayer.Value);
references.Add(_hurtEnemy.Value);
references.Add(_hurtEnemyRe.Value);
references.Add(_hurtEnemyCm.Value);
references.Add(_hurtEnemyBullet.Value);
references.Add(_hurtEnemyNeedler.Value);
references.Add(_hurtEnemyPlasma.Value);
references.Add(_hurtEnemySniper.Value);
references.Add(_hurtEnemyGrenade.Value);
references.Add(_hurtEnemyExplosion.Value);
references.Add(_hurtEnemyMelee.Value);
references.Add(_hurtEnemyFlame.Value);
references.Add(_hurtEnemyShotgun.Value);
references.Add(_hurtEnemyVehicle.Value);
references.Add(_hurtEnemyMountedweapon.Value);
references.Add(_killedFriend.Value);
references.Add(_killedFriendCm.Value);
references.Add(_killedFriendPlayer.Value);
references.Add(_killedFriendPlayerCm.Value);
references.Add(_killedEnemy.Value);
references.Add(_killedEnemyCm.Value);
references.Add(_killedEnemyPlayer.Value);
references.Add(_killedEnemyPlayerCm.Value);
references.Add(_killedEnemyCovenant.Value);
references.Add(_killedEnemyCovenantCm.Value);
references.Add(_killedEnemyFloodcombat.Value);
references.Add(_killedEnemyFloodcombatCm.Value);
references.Add(_killedEnemyFloodcarrier.Value);
references.Add(_killedEnemyFloodcarrierCm.Value);
references.Add(_killedEnemySentinel.Value);
references.Add(_killedEnemySentinelCm.Value);
references.Add(_killedEnemyBullet.Value);
references.Add(_killedEnemyNeedler.Value);
references.Add(_killedEnemyPlasma.Value);
references.Add(_killedEnemySniper.Value);
references.Add(_killedEnemyGrenade.Value);
references.Add(_killedEnemyExplosion.Value);
references.Add(_killedEnemyMelee.Value);
references.Add(_killedEnemyFlame.Value);
references.Add(_killedEnemyShotgun.Value);
references.Add(_killedEnemyVehicle.Value);
references.Add(_killedEnemyMountedweapon.Value);
references.Add(_killingSpree.Value);
references.Add(_playerKillCm.Value);
references.Add(_playerKillBulletCm.Value);
references.Add(_playerKillNeedlerCm.Value);
references.Add(_playerKillPlasmaCm.Value);
references.Add(_playerKillSniperCm.Value);
references.Add(_anyoneKillGrenadeCm.Value);
references.Add(_playerKillExplosionCm.Value);
references.Add(_playerKillMeleeCm.Value);
references.Add(_playerKillFlameCm.Value);
references.Add(_playerKillShotgunCm.Value);
references.Add(_playerKillVehicleCm.Value);
references.Add(_playerKillMountedweaponCm.Value);
references.Add(_playerKilllingSpreeCm.Value);
references.Add(_friendDied.Value);
references.Add(_friendPlayerDied.Value);
references.Add(_friendKilledByFriend.Value);
references.Add(_friendKilledByFriendlyPlayer.Value);
references.Add(_friendKilledByEnemy.Value);
references.Add(_friendKilledByEnemyPlayer.Value);
references.Add(_friendKilledByCovenant.Value);
references.Add(_friendKilledByFlood.Value);
references.Add(_friendKilledBySentinel.Value);
references.Add(_friendBetrayed.Value);
references.Add(_newCombatAlone.Value);
references.Add(_newEnemyRecentCombat.Value);
references.Add(_oldEnemySighted.Value);
references.Add(_unexpectedEnemy.Value);
references.Add(_deadFriendFound.Value);
references.Add(_allianceBroken.Value);
references.Add(_allianceReformed.Value);
references.Add(_grenadeThrowing.Value);
references.Add(_grenadeSighted.Value);
references.Add(_grenadeStartle.Value);
references.Add(_grenadeDangerEnemy.Value);
references.Add(_grenadeDangerSelf.Value);
references.Add(_grenadeDangerFriend.Value);
references.Add(_newCombatGroupRe.Value);
references.Add(_newCombatNearbyRe.Value);
references.Add(_alertFriend.Value);
references.Add(_alertFriendRe.Value);
references.Add(_alertLostContact.Value);
references.Add(_alertLostContactRe.Value);
references.Add(_blocked.Value);
references.Add(_blockedRe.Value);
references.Add(_searchStart.Value);
references.Add(_searchQuery.Value);
references.Add(_searchQueryRe.Value);
references.Add(_searchReport.Value);
references.Add(_searchAbandon.Value);
references.Add(_searchGroupAbandon.Value);
references.Add(_groupUncover.Value);
references.Add(_groupUncoverRe.Value);
references.Add(_advance.Value);
references.Add(_advanceRe.Value);
references.Add(_retreat.Value);
references.Add(_retreatRe.Value);
references.Add(_cover.Value);
references.Add(_sightedFriendPlayer.Value);
references.Add(_shooting.Value);
references.Add(_shootingVehicle.Value);
references.Add(_shootingBerserk.Value);
references.Add(_shootingGroup.Value);
references.Add(_shootingTraitor.Value);
references.Add(_taunt.Value);
references.Add(_tauntRe.Value);
references.Add(_flee.Value);
references.Add(_fleeRe.Value);
references.Add(_fleeLeaderDied.Value);
references.Add(_attemptedFlee.Value);
references.Add(_attemptedFleeRe.Value);
references.Add(_lostContact.Value);
references.Add(_hidingFinished.Value);
references.Add(_vehicleEntry.Value);
references.Add(_vehicleExit.Value);
references.Add(_vehicleWoohoo.Value);
references.Add(_vehicleScared.Value);
references.Add(_vehicleCollision.Value);
references.Add(_partiallySighted.Value);
references.Add(_nothingThere.Value);
references.Add(_pleading.Value);
references.Add(_surprise.Value);
references.Add(_berserk.Value);
references.Add(_meleeAttack.Value);
references.Add(_dive.Value);
references.Add(_uncoverExclamation.Value);
references.Add(_leapAttack.Value);
references.Add(_resurrection.Value);
references.Add(_celebration.Value);
references.Add(_checkBodyEnemy.Value);
references.Add(_checkBodyFriend.Value);
references.Add(_shootingDeadEnemy.Value);
references.Add(_shootingDeadEnemyPlayer.Value);
references.Add(_alone.Value);
references.Add(_unscathed.Value);
references.Add(_seriouslyWounded.Value);
references.Add(_seriouslyWoundedRe.Value);
references.Add(_massacre.Value);
references.Add(_massacreRe.Value);
references.Add(_rout.Value);
references.Add(_routRe.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference IdleNoncombat {
        get {
          return this._idleNoncombat;
        }
        set {
          this._idleNoncombat = value;
        }
      }
      public TagReference IdleCombat {
        get {
          return this._idleCombat;
        }
        set {
          this._idleCombat = value;
        }
      }
      public TagReference IdleFlee {
        get {
          return this._idleFlee;
        }
        set {
          this._idleFlee = value;
        }
      }
      public TagReference PainBodyMinor {
        get {
          return this._painBodyMinor;
        }
        set {
          this._painBodyMinor = value;
        }
      }
      public TagReference PainBodyMajor {
        get {
          return this._painBodyMajor;
        }
        set {
          this._painBodyMajor = value;
        }
      }
      public TagReference PainShield {
        get {
          return this._painShield;
        }
        set {
          this._painShield = value;
        }
      }
      public TagReference PainFalling {
        get {
          return this._painFalling;
        }
        set {
          this._painFalling = value;
        }
      }
      public TagReference ScreamFear {
        get {
          return this._screamFear;
        }
        set {
          this._screamFear = value;
        }
      }
      public TagReference ScreamPain {
        get {
          return this._screamPain;
        }
        set {
          this._screamPain = value;
        }
      }
      public TagReference MaimedLimb {
        get {
          return this._maimedLimb;
        }
        set {
          this._maimedLimb = value;
        }
      }
      public TagReference MaimedHead {
        get {
          return this._maimedHead;
        }
        set {
          this._maimedHead = value;
        }
      }
      public TagReference DeathQuiet {
        get {
          return this._deathQuiet;
        }
        set {
          this._deathQuiet = value;
        }
      }
      public TagReference DeathViolent {
        get {
          return this._deathViolent;
        }
        set {
          this._deathViolent = value;
        }
      }
      public TagReference DeathFalling {
        get {
          return this._deathFalling;
        }
        set {
          this._deathFalling = value;
        }
      }
      public TagReference DeathAgonizing {
        get {
          return this._deathAgonizing;
        }
        set {
          this._deathAgonizing = value;
        }
      }
      public TagReference DeathInstant {
        get {
          return this._deathInstant;
        }
        set {
          this._deathInstant = value;
        }
      }
      public TagReference DeathFlying {
        get {
          return this._deathFlying;
        }
        set {
          this._deathFlying = value;
        }
      }
      public TagReference DamagedFriend {
        get {
          return this._damagedFriend;
        }
        set {
          this._damagedFriend = value;
        }
      }
      public TagReference DamagedFriendPlayer {
        get {
          return this._damagedFriendPlayer;
        }
        set {
          this._damagedFriendPlayer = value;
        }
      }
      public TagReference DamagedEnemy {
        get {
          return this._damagedEnemy;
        }
        set {
          this._damagedEnemy = value;
        }
      }
      public TagReference DamagedEnemyCm {
        get {
          return this._damagedEnemyCm;
        }
        set {
          this._damagedEnemyCm = value;
        }
      }
      public TagReference HurtFriend {
        get {
          return this._hurtFriend;
        }
        set {
          this._hurtFriend = value;
        }
      }
      public TagReference HurtFriendRe {
        get {
          return this._hurtFriendRe;
        }
        set {
          this._hurtFriendRe = value;
        }
      }
      public TagReference HurtFriendPlayer {
        get {
          return this._hurtFriendPlayer;
        }
        set {
          this._hurtFriendPlayer = value;
        }
      }
      public TagReference HurtEnemy {
        get {
          return this._hurtEnemy;
        }
        set {
          this._hurtEnemy = value;
        }
      }
      public TagReference HurtEnemyRe {
        get {
          return this._hurtEnemyRe;
        }
        set {
          this._hurtEnemyRe = value;
        }
      }
      public TagReference HurtEnemyCm {
        get {
          return this._hurtEnemyCm;
        }
        set {
          this._hurtEnemyCm = value;
        }
      }
      public TagReference HurtEnemyBullet {
        get {
          return this._hurtEnemyBullet;
        }
        set {
          this._hurtEnemyBullet = value;
        }
      }
      public TagReference HurtEnemyNeedler {
        get {
          return this._hurtEnemyNeedler;
        }
        set {
          this._hurtEnemyNeedler = value;
        }
      }
      public TagReference HurtEnemyPlasma {
        get {
          return this._hurtEnemyPlasma;
        }
        set {
          this._hurtEnemyPlasma = value;
        }
      }
      public TagReference HurtEnemySniper {
        get {
          return this._hurtEnemySniper;
        }
        set {
          this._hurtEnemySniper = value;
        }
      }
      public TagReference HurtEnemyGrenade {
        get {
          return this._hurtEnemyGrenade;
        }
        set {
          this._hurtEnemyGrenade = value;
        }
      }
      public TagReference HurtEnemyExplosion {
        get {
          return this._hurtEnemyExplosion;
        }
        set {
          this._hurtEnemyExplosion = value;
        }
      }
      public TagReference HurtEnemyMelee {
        get {
          return this._hurtEnemyMelee;
        }
        set {
          this._hurtEnemyMelee = value;
        }
      }
      public TagReference HurtEnemyFlame {
        get {
          return this._hurtEnemyFlame;
        }
        set {
          this._hurtEnemyFlame = value;
        }
      }
      public TagReference HurtEnemyShotgun {
        get {
          return this._hurtEnemyShotgun;
        }
        set {
          this._hurtEnemyShotgun = value;
        }
      }
      public TagReference HurtEnemyVehicle {
        get {
          return this._hurtEnemyVehicle;
        }
        set {
          this._hurtEnemyVehicle = value;
        }
      }
      public TagReference HurtEnemyMountedweapon {
        get {
          return this._hurtEnemyMountedweapon;
        }
        set {
          this._hurtEnemyMountedweapon = value;
        }
      }
      public TagReference KilledFriend {
        get {
          return this._killedFriend;
        }
        set {
          this._killedFriend = value;
        }
      }
      public TagReference KilledFriendCm {
        get {
          return this._killedFriendCm;
        }
        set {
          this._killedFriendCm = value;
        }
      }
      public TagReference KilledFriendPlayer {
        get {
          return this._killedFriendPlayer;
        }
        set {
          this._killedFriendPlayer = value;
        }
      }
      public TagReference KilledFriendPlayerCm {
        get {
          return this._killedFriendPlayerCm;
        }
        set {
          this._killedFriendPlayerCm = value;
        }
      }
      public TagReference KilledEnemy {
        get {
          return this._killedEnemy;
        }
        set {
          this._killedEnemy = value;
        }
      }
      public TagReference KilledEnemyCm {
        get {
          return this._killedEnemyCm;
        }
        set {
          this._killedEnemyCm = value;
        }
      }
      public TagReference KilledEnemyPlayer {
        get {
          return this._killedEnemyPlayer;
        }
        set {
          this._killedEnemyPlayer = value;
        }
      }
      public TagReference KilledEnemyPlayerCm {
        get {
          return this._killedEnemyPlayerCm;
        }
        set {
          this._killedEnemyPlayerCm = value;
        }
      }
      public TagReference KilledEnemyCovenant {
        get {
          return this._killedEnemyCovenant;
        }
        set {
          this._killedEnemyCovenant = value;
        }
      }
      public TagReference KilledEnemyCovenantCm {
        get {
          return this._killedEnemyCovenantCm;
        }
        set {
          this._killedEnemyCovenantCm = value;
        }
      }
      public TagReference KilledEnemyFloodcombat {
        get {
          return this._killedEnemyFloodcombat;
        }
        set {
          this._killedEnemyFloodcombat = value;
        }
      }
      public TagReference KilledEnemyFloodcombatCm {
        get {
          return this._killedEnemyFloodcombatCm;
        }
        set {
          this._killedEnemyFloodcombatCm = value;
        }
      }
      public TagReference KilledEnemyFloodcarrier {
        get {
          return this._killedEnemyFloodcarrier;
        }
        set {
          this._killedEnemyFloodcarrier = value;
        }
      }
      public TagReference KilledEnemyFloodcarrierCm {
        get {
          return this._killedEnemyFloodcarrierCm;
        }
        set {
          this._killedEnemyFloodcarrierCm = value;
        }
      }
      public TagReference KilledEnemySentinel {
        get {
          return this._killedEnemySentinel;
        }
        set {
          this._killedEnemySentinel = value;
        }
      }
      public TagReference KilledEnemySentinelCm {
        get {
          return this._killedEnemySentinelCm;
        }
        set {
          this._killedEnemySentinelCm = value;
        }
      }
      public TagReference KilledEnemyBullet {
        get {
          return this._killedEnemyBullet;
        }
        set {
          this._killedEnemyBullet = value;
        }
      }
      public TagReference KilledEnemyNeedler {
        get {
          return this._killedEnemyNeedler;
        }
        set {
          this._killedEnemyNeedler = value;
        }
      }
      public TagReference KilledEnemyPlasma {
        get {
          return this._killedEnemyPlasma;
        }
        set {
          this._killedEnemyPlasma = value;
        }
      }
      public TagReference KilledEnemySniper {
        get {
          return this._killedEnemySniper;
        }
        set {
          this._killedEnemySniper = value;
        }
      }
      public TagReference KilledEnemyGrenade {
        get {
          return this._killedEnemyGrenade;
        }
        set {
          this._killedEnemyGrenade = value;
        }
      }
      public TagReference KilledEnemyExplosion {
        get {
          return this._killedEnemyExplosion;
        }
        set {
          this._killedEnemyExplosion = value;
        }
      }
      public TagReference KilledEnemyMelee {
        get {
          return this._killedEnemyMelee;
        }
        set {
          this._killedEnemyMelee = value;
        }
      }
      public TagReference KilledEnemyFlame {
        get {
          return this._killedEnemyFlame;
        }
        set {
          this._killedEnemyFlame = value;
        }
      }
      public TagReference KilledEnemyShotgun {
        get {
          return this._killedEnemyShotgun;
        }
        set {
          this._killedEnemyShotgun = value;
        }
      }
      public TagReference KilledEnemyVehicle {
        get {
          return this._killedEnemyVehicle;
        }
        set {
          this._killedEnemyVehicle = value;
        }
      }
      public TagReference KilledEnemyMountedweapon {
        get {
          return this._killedEnemyMountedweapon;
        }
        set {
          this._killedEnemyMountedweapon = value;
        }
      }
      public TagReference KillingSpree {
        get {
          return this._killingSpree;
        }
        set {
          this._killingSpree = value;
        }
      }
      public TagReference PlayerKillCm {
        get {
          return this._playerKillCm;
        }
        set {
          this._playerKillCm = value;
        }
      }
      public TagReference PlayerKillBulletCm {
        get {
          return this._playerKillBulletCm;
        }
        set {
          this._playerKillBulletCm = value;
        }
      }
      public TagReference PlayerKillNeedlerCm {
        get {
          return this._playerKillNeedlerCm;
        }
        set {
          this._playerKillNeedlerCm = value;
        }
      }
      public TagReference PlayerKillPlasmaCm {
        get {
          return this._playerKillPlasmaCm;
        }
        set {
          this._playerKillPlasmaCm = value;
        }
      }
      public TagReference PlayerKillSniperCm {
        get {
          return this._playerKillSniperCm;
        }
        set {
          this._playerKillSniperCm = value;
        }
      }
      public TagReference AnyoneKillGrenadeCm {
        get {
          return this._anyoneKillGrenadeCm;
        }
        set {
          this._anyoneKillGrenadeCm = value;
        }
      }
      public TagReference PlayerKillExplosionCm {
        get {
          return this._playerKillExplosionCm;
        }
        set {
          this._playerKillExplosionCm = value;
        }
      }
      public TagReference PlayerKillMeleeCm {
        get {
          return this._playerKillMeleeCm;
        }
        set {
          this._playerKillMeleeCm = value;
        }
      }
      public TagReference PlayerKillFlameCm {
        get {
          return this._playerKillFlameCm;
        }
        set {
          this._playerKillFlameCm = value;
        }
      }
      public TagReference PlayerKillShotgunCm {
        get {
          return this._playerKillShotgunCm;
        }
        set {
          this._playerKillShotgunCm = value;
        }
      }
      public TagReference PlayerKillVehicleCm {
        get {
          return this._playerKillVehicleCm;
        }
        set {
          this._playerKillVehicleCm = value;
        }
      }
      public TagReference PlayerKillMountedweaponCm {
        get {
          return this._playerKillMountedweaponCm;
        }
        set {
          this._playerKillMountedweaponCm = value;
        }
      }
      public TagReference PlayerKilllingSpreeCm {
        get {
          return this._playerKilllingSpreeCm;
        }
        set {
          this._playerKilllingSpreeCm = value;
        }
      }
      public TagReference FriendDied {
        get {
          return this._friendDied;
        }
        set {
          this._friendDied = value;
        }
      }
      public TagReference FriendPlayerDied {
        get {
          return this._friendPlayerDied;
        }
        set {
          this._friendPlayerDied = value;
        }
      }
      public TagReference FriendKilledByFriend {
        get {
          return this._friendKilledByFriend;
        }
        set {
          this._friendKilledByFriend = value;
        }
      }
      public TagReference FriendKilledByFriendlyPlayer {
        get {
          return this._friendKilledByFriendlyPlayer;
        }
        set {
          this._friendKilledByFriendlyPlayer = value;
        }
      }
      public TagReference FriendKilledByEnemy {
        get {
          return this._friendKilledByEnemy;
        }
        set {
          this._friendKilledByEnemy = value;
        }
      }
      public TagReference FriendKilledByEnemyPlayer {
        get {
          return this._friendKilledByEnemyPlayer;
        }
        set {
          this._friendKilledByEnemyPlayer = value;
        }
      }
      public TagReference FriendKilledByCovenant {
        get {
          return this._friendKilledByCovenant;
        }
        set {
          this._friendKilledByCovenant = value;
        }
      }
      public TagReference FriendKilledByFlood {
        get {
          return this._friendKilledByFlood;
        }
        set {
          this._friendKilledByFlood = value;
        }
      }
      public TagReference FriendKilledBySentinel {
        get {
          return this._friendKilledBySentinel;
        }
        set {
          this._friendKilledBySentinel = value;
        }
      }
      public TagReference FriendBetrayed {
        get {
          return this._friendBetrayed;
        }
        set {
          this._friendBetrayed = value;
        }
      }
      public TagReference NewCombatAlone {
        get {
          return this._newCombatAlone;
        }
        set {
          this._newCombatAlone = value;
        }
      }
      public TagReference NewEnemyRecentCombat {
        get {
          return this._newEnemyRecentCombat;
        }
        set {
          this._newEnemyRecentCombat = value;
        }
      }
      public TagReference OldEnemySighted {
        get {
          return this._oldEnemySighted;
        }
        set {
          this._oldEnemySighted = value;
        }
      }
      public TagReference UnexpectedEnemy {
        get {
          return this._unexpectedEnemy;
        }
        set {
          this._unexpectedEnemy = value;
        }
      }
      public TagReference DeadFriendFound {
        get {
          return this._deadFriendFound;
        }
        set {
          this._deadFriendFound = value;
        }
      }
      public TagReference AllianceBroken {
        get {
          return this._allianceBroken;
        }
        set {
          this._allianceBroken = value;
        }
      }
      public TagReference AllianceReformed {
        get {
          return this._allianceReformed;
        }
        set {
          this._allianceReformed = value;
        }
      }
      public TagReference GrenadeThrowing {
        get {
          return this._grenadeThrowing;
        }
        set {
          this._grenadeThrowing = value;
        }
      }
      public TagReference GrenadeSighted {
        get {
          return this._grenadeSighted;
        }
        set {
          this._grenadeSighted = value;
        }
      }
      public TagReference GrenadeStartle {
        get {
          return this._grenadeStartle;
        }
        set {
          this._grenadeStartle = value;
        }
      }
      public TagReference GrenadeDangerEnemy {
        get {
          return this._grenadeDangerEnemy;
        }
        set {
          this._grenadeDangerEnemy = value;
        }
      }
      public TagReference GrenadeDangerSelf {
        get {
          return this._grenadeDangerSelf;
        }
        set {
          this._grenadeDangerSelf = value;
        }
      }
      public TagReference GrenadeDangerFriend {
        get {
          return this._grenadeDangerFriend;
        }
        set {
          this._grenadeDangerFriend = value;
        }
      }
      public TagReference NewCombatGroupRe {
        get {
          return this._newCombatGroupRe;
        }
        set {
          this._newCombatGroupRe = value;
        }
      }
      public TagReference NewCombatNearbyRe {
        get {
          return this._newCombatNearbyRe;
        }
        set {
          this._newCombatNearbyRe = value;
        }
      }
      public TagReference AlertFriend {
        get {
          return this._alertFriend;
        }
        set {
          this._alertFriend = value;
        }
      }
      public TagReference AlertFriendRe {
        get {
          return this._alertFriendRe;
        }
        set {
          this._alertFriendRe = value;
        }
      }
      public TagReference AlertLostContact {
        get {
          return this._alertLostContact;
        }
        set {
          this._alertLostContact = value;
        }
      }
      public TagReference AlertLostContactRe {
        get {
          return this._alertLostContactRe;
        }
        set {
          this._alertLostContactRe = value;
        }
      }
      public TagReference Blocked {
        get {
          return this._blocked;
        }
        set {
          this._blocked = value;
        }
      }
      public TagReference BlockedRe {
        get {
          return this._blockedRe;
        }
        set {
          this._blockedRe = value;
        }
      }
      public TagReference SearchStart {
        get {
          return this._searchStart;
        }
        set {
          this._searchStart = value;
        }
      }
      public TagReference SearchQuery {
        get {
          return this._searchQuery;
        }
        set {
          this._searchQuery = value;
        }
      }
      public TagReference SearchQueryRe {
        get {
          return this._searchQueryRe;
        }
        set {
          this._searchQueryRe = value;
        }
      }
      public TagReference SearchReport {
        get {
          return this._searchReport;
        }
        set {
          this._searchReport = value;
        }
      }
      public TagReference SearchAbandon {
        get {
          return this._searchAbandon;
        }
        set {
          this._searchAbandon = value;
        }
      }
      public TagReference SearchGroupAbandon {
        get {
          return this._searchGroupAbandon;
        }
        set {
          this._searchGroupAbandon = value;
        }
      }
      public TagReference GroupUncover {
        get {
          return this._groupUncover;
        }
        set {
          this._groupUncover = value;
        }
      }
      public TagReference GroupUncoverRe {
        get {
          return this._groupUncoverRe;
        }
        set {
          this._groupUncoverRe = value;
        }
      }
      public TagReference Advance {
        get {
          return this._advance;
        }
        set {
          this._advance = value;
        }
      }
      public TagReference AdvanceRe {
        get {
          return this._advanceRe;
        }
        set {
          this._advanceRe = value;
        }
      }
      public TagReference Retreat {
        get {
          return this._retreat;
        }
        set {
          this._retreat = value;
        }
      }
      public TagReference RetreatRe {
        get {
          return this._retreatRe;
        }
        set {
          this._retreatRe = value;
        }
      }
      public TagReference Cover {
        get {
          return this._cover;
        }
        set {
          this._cover = value;
        }
      }
      public TagReference SightedFriendPlayer {
        get {
          return this._sightedFriendPlayer;
        }
        set {
          this._sightedFriendPlayer = value;
        }
      }
      public TagReference Shooting {
        get {
          return this._shooting;
        }
        set {
          this._shooting = value;
        }
      }
      public TagReference ShootingVehicle {
        get {
          return this._shootingVehicle;
        }
        set {
          this._shootingVehicle = value;
        }
      }
      public TagReference ShootingBerserk {
        get {
          return this._shootingBerserk;
        }
        set {
          this._shootingBerserk = value;
        }
      }
      public TagReference ShootingGroup {
        get {
          return this._shootingGroup;
        }
        set {
          this._shootingGroup = value;
        }
      }
      public TagReference ShootingTraitor {
        get {
          return this._shootingTraitor;
        }
        set {
          this._shootingTraitor = value;
        }
      }
      public TagReference Taunt {
        get {
          return this._taunt;
        }
        set {
          this._taunt = value;
        }
      }
      public TagReference TauntRe {
        get {
          return this._tauntRe;
        }
        set {
          this._tauntRe = value;
        }
      }
      public TagReference Flee {
        get {
          return this._flee;
        }
        set {
          this._flee = value;
        }
      }
      public TagReference FleeRe {
        get {
          return this._fleeRe;
        }
        set {
          this._fleeRe = value;
        }
      }
      public TagReference FleeLeaderDied {
        get {
          return this._fleeLeaderDied;
        }
        set {
          this._fleeLeaderDied = value;
        }
      }
      public TagReference AttemptedFlee {
        get {
          return this._attemptedFlee;
        }
        set {
          this._attemptedFlee = value;
        }
      }
      public TagReference AttemptedFleeRe {
        get {
          return this._attemptedFleeRe;
        }
        set {
          this._attemptedFleeRe = value;
        }
      }
      public TagReference LostContact {
        get {
          return this._lostContact;
        }
        set {
          this._lostContact = value;
        }
      }
      public TagReference HidingFinished {
        get {
          return this._hidingFinished;
        }
        set {
          this._hidingFinished = value;
        }
      }
      public TagReference VehicleEntry {
        get {
          return this._vehicleEntry;
        }
        set {
          this._vehicleEntry = value;
        }
      }
      public TagReference VehicleExit {
        get {
          return this._vehicleExit;
        }
        set {
          this._vehicleExit = value;
        }
      }
      public TagReference VehicleWoohoo {
        get {
          return this._vehicleWoohoo;
        }
        set {
          this._vehicleWoohoo = value;
        }
      }
      public TagReference VehicleScared {
        get {
          return this._vehicleScared;
        }
        set {
          this._vehicleScared = value;
        }
      }
      public TagReference VehicleCollision {
        get {
          return this._vehicleCollision;
        }
        set {
          this._vehicleCollision = value;
        }
      }
      public TagReference PartiallySighted {
        get {
          return this._partiallySighted;
        }
        set {
          this._partiallySighted = value;
        }
      }
      public TagReference NothingThere {
        get {
          return this._nothingThere;
        }
        set {
          this._nothingThere = value;
        }
      }
      public TagReference Pleading {
        get {
          return this._pleading;
        }
        set {
          this._pleading = value;
        }
      }
      public TagReference Surprise {
        get {
          return this._surprise;
        }
        set {
          this._surprise = value;
        }
      }
      public TagReference Berserk {
        get {
          return this._berserk;
        }
        set {
          this._berserk = value;
        }
      }
      public TagReference MeleeAttack {
        get {
          return this._meleeAttack;
        }
        set {
          this._meleeAttack = value;
        }
      }
      public TagReference Dive {
        get {
          return this._dive;
        }
        set {
          this._dive = value;
        }
      }
      public TagReference UncoverExclamation {
        get {
          return this._uncoverExclamation;
        }
        set {
          this._uncoverExclamation = value;
        }
      }
      public TagReference LeapAttack {
        get {
          return this._leapAttack;
        }
        set {
          this._leapAttack = value;
        }
      }
      public TagReference Resurrection {
        get {
          return this._resurrection;
        }
        set {
          this._resurrection = value;
        }
      }
      public TagReference Celebration {
        get {
          return this._celebration;
        }
        set {
          this._celebration = value;
        }
      }
      public TagReference CheckBodyEnemy {
        get {
          return this._checkBodyEnemy;
        }
        set {
          this._checkBodyEnemy = value;
        }
      }
      public TagReference CheckBodyFriend {
        get {
          return this._checkBodyFriend;
        }
        set {
          this._checkBodyFriend = value;
        }
      }
      public TagReference ShootingDeadEnemy {
        get {
          return this._shootingDeadEnemy;
        }
        set {
          this._shootingDeadEnemy = value;
        }
      }
      public TagReference ShootingDeadEnemyPlayer {
        get {
          return this._shootingDeadEnemyPlayer;
        }
        set {
          this._shootingDeadEnemyPlayer = value;
        }
      }
      public TagReference Alone {
        get {
          return this._alone;
        }
        set {
          this._alone = value;
        }
      }
      public TagReference Unscathed {
        get {
          return this._unscathed;
        }
        set {
          this._unscathed = value;
        }
      }
      public TagReference SeriouslyWounded {
        get {
          return this._seriouslyWounded;
        }
        set {
          this._seriouslyWounded = value;
        }
      }
      public TagReference SeriouslyWoundedRe {
        get {
          return this._seriouslyWoundedRe;
        }
        set {
          this._seriouslyWoundedRe = value;
        }
      }
      public TagReference Massacre {
        get {
          return this._massacre;
        }
        set {
          this._massacre = value;
        }
      }
      public TagReference MassacreRe {
        get {
          return this._massacreRe;
        }
        set {
          this._massacreRe = value;
        }
      }
      public TagReference Rout {
        get {
          return this._rout;
        }
        set {
          this._rout = value;
        }
      }
      public TagReference RoutRe {
        get {
          return this._routRe;
        }
        set {
          this._routRe = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _idleNoncombat.Read(reader);
        _idleCombat.Read(reader);
        _idleFlee.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _painBodyMinor.Read(reader);
        _painBodyMajor.Read(reader);
        _painShield.Read(reader);
        _painFalling.Read(reader);
        _screamFear.Read(reader);
        _screamPain.Read(reader);
        _maimedLimb.Read(reader);
        _maimedHead.Read(reader);
        _deathQuiet.Read(reader);
        _deathViolent.Read(reader);
        _deathFalling.Read(reader);
        _deathAgonizing.Read(reader);
        _deathInstant.Read(reader);
        _deathFlying.Read(reader);
        _unnamed7.Read(reader);
        _damagedFriend.Read(reader);
        _damagedFriendPlayer.Read(reader);
        _damagedEnemy.Read(reader);
        _damagedEnemyCm.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _hurtFriend.Read(reader);
        _hurtFriendRe.Read(reader);
        _hurtFriendPlayer.Read(reader);
        _hurtEnemy.Read(reader);
        _hurtEnemyRe.Read(reader);
        _hurtEnemyCm.Read(reader);
        _hurtEnemyBullet.Read(reader);
        _hurtEnemyNeedler.Read(reader);
        _hurtEnemyPlasma.Read(reader);
        _hurtEnemySniper.Read(reader);
        _hurtEnemyGrenade.Read(reader);
        _hurtEnemyExplosion.Read(reader);
        _hurtEnemyMelee.Read(reader);
        _hurtEnemyFlame.Read(reader);
        _hurtEnemyShotgun.Read(reader);
        _hurtEnemyVehicle.Read(reader);
        _hurtEnemyMountedweapon.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _killedFriend.Read(reader);
        _killedFriendCm.Read(reader);
        _killedFriendPlayer.Read(reader);
        _killedFriendPlayerCm.Read(reader);
        _killedEnemy.Read(reader);
        _killedEnemyCm.Read(reader);
        _killedEnemyPlayer.Read(reader);
        _killedEnemyPlayerCm.Read(reader);
        _killedEnemyCovenant.Read(reader);
        _killedEnemyCovenantCm.Read(reader);
        _killedEnemyFloodcombat.Read(reader);
        _killedEnemyFloodcombatCm.Read(reader);
        _killedEnemyFloodcarrier.Read(reader);
        _killedEnemyFloodcarrierCm.Read(reader);
        _killedEnemySentinel.Read(reader);
        _killedEnemySentinelCm.Read(reader);
        _killedEnemyBullet.Read(reader);
        _killedEnemyNeedler.Read(reader);
        _killedEnemyPlasma.Read(reader);
        _killedEnemySniper.Read(reader);
        _killedEnemyGrenade.Read(reader);
        _killedEnemyExplosion.Read(reader);
        _killedEnemyMelee.Read(reader);
        _killedEnemyFlame.Read(reader);
        _killedEnemyShotgun.Read(reader);
        _killedEnemyVehicle.Read(reader);
        _killedEnemyMountedweapon.Read(reader);
        _killingSpree.Read(reader);
        _unnamed15.Read(reader);
        _unnamed16.Read(reader);
        _unnamed17.Read(reader);
        _playerKillCm.Read(reader);
        _playerKillBulletCm.Read(reader);
        _playerKillNeedlerCm.Read(reader);
        _playerKillPlasmaCm.Read(reader);
        _playerKillSniperCm.Read(reader);
        _anyoneKillGrenadeCm.Read(reader);
        _playerKillExplosionCm.Read(reader);
        _playerKillMeleeCm.Read(reader);
        _playerKillFlameCm.Read(reader);
        _playerKillShotgunCm.Read(reader);
        _playerKillVehicleCm.Read(reader);
        _playerKillMountedweaponCm.Read(reader);
        _playerKilllingSpreeCm.Read(reader);
        _unnamed18.Read(reader);
        _unnamed19.Read(reader);
        _unnamed20.Read(reader);
        _friendDied.Read(reader);
        _friendPlayerDied.Read(reader);
        _friendKilledByFriend.Read(reader);
        _friendKilledByFriendlyPlayer.Read(reader);
        _friendKilledByEnemy.Read(reader);
        _friendKilledByEnemyPlayer.Read(reader);
        _friendKilledByCovenant.Read(reader);
        _friendKilledByFlood.Read(reader);
        _friendKilledBySentinel.Read(reader);
        _friendBetrayed.Read(reader);
        _unnamed21.Read(reader);
        _unnamed22.Read(reader);
        _newCombatAlone.Read(reader);
        _newEnemyRecentCombat.Read(reader);
        _oldEnemySighted.Read(reader);
        _unexpectedEnemy.Read(reader);
        _deadFriendFound.Read(reader);
        _allianceBroken.Read(reader);
        _allianceReformed.Read(reader);
        _grenadeThrowing.Read(reader);
        _grenadeSighted.Read(reader);
        _grenadeStartle.Read(reader);
        _grenadeDangerEnemy.Read(reader);
        _grenadeDangerSelf.Read(reader);
        _grenadeDangerFriend.Read(reader);
        _unnamed23.Read(reader);
        _unnamed24.Read(reader);
        _newCombatGroupRe.Read(reader);
        _newCombatNearbyRe.Read(reader);
        _alertFriend.Read(reader);
        _alertFriendRe.Read(reader);
        _alertLostContact.Read(reader);
        _alertLostContactRe.Read(reader);
        _blocked.Read(reader);
        _blockedRe.Read(reader);
        _searchStart.Read(reader);
        _searchQuery.Read(reader);
        _searchQueryRe.Read(reader);
        _searchReport.Read(reader);
        _searchAbandon.Read(reader);
        _searchGroupAbandon.Read(reader);
        _groupUncover.Read(reader);
        _groupUncoverRe.Read(reader);
        _advance.Read(reader);
        _advanceRe.Read(reader);
        _retreat.Read(reader);
        _retreatRe.Read(reader);
        _cover.Read(reader);
        _unnamed25.Read(reader);
        _unnamed26.Read(reader);
        _unnamed27.Read(reader);
        _unnamed28.Read(reader);
        _sightedFriendPlayer.Read(reader);
        _shooting.Read(reader);
        _shootingVehicle.Read(reader);
        _shootingBerserk.Read(reader);
        _shootingGroup.Read(reader);
        _shootingTraitor.Read(reader);
        _taunt.Read(reader);
        _tauntRe.Read(reader);
        _flee.Read(reader);
        _fleeRe.Read(reader);
        _fleeLeaderDied.Read(reader);
        _attemptedFlee.Read(reader);
        _attemptedFleeRe.Read(reader);
        _lostContact.Read(reader);
        _hidingFinished.Read(reader);
        _vehicleEntry.Read(reader);
        _vehicleExit.Read(reader);
        _vehicleWoohoo.Read(reader);
        _vehicleScared.Read(reader);
        _vehicleCollision.Read(reader);
        _partiallySighted.Read(reader);
        _nothingThere.Read(reader);
        _pleading.Read(reader);
        _unnamed29.Read(reader);
        _unnamed30.Read(reader);
        _unnamed31.Read(reader);
        _unnamed32.Read(reader);
        _unnamed33.Read(reader);
        _unnamed34.Read(reader);
        _surprise.Read(reader);
        _berserk.Read(reader);
        _meleeAttack.Read(reader);
        _dive.Read(reader);
        _uncoverExclamation.Read(reader);
        _leapAttack.Read(reader);
        _resurrection.Read(reader);
        _unnamed35.Read(reader);
        _unnamed36.Read(reader);
        _unnamed37.Read(reader);
        _unnamed38.Read(reader);
        _celebration.Read(reader);
        _checkBodyEnemy.Read(reader);
        _checkBodyFriend.Read(reader);
        _shootingDeadEnemy.Read(reader);
        _shootingDeadEnemyPlayer.Read(reader);
        _unnamed39.Read(reader);
        _unnamed40.Read(reader);
        _unnamed41.Read(reader);
        _unnamed42.Read(reader);
        _alone.Read(reader);
        _unscathed.Read(reader);
        _seriouslyWounded.Read(reader);
        _seriouslyWoundedRe.Read(reader);
        _massacre.Read(reader);
        _massacreRe.Read(reader);
        _rout.Read(reader);
        _routRe.Read(reader);
        _unnamed43.Read(reader);
        _unnamed44.Read(reader);
        _unnamed45.Read(reader);
        _unnamed46.Read(reader);
        _unnamed47.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _idleNoncombat.ReadString(reader);
        _idleCombat.ReadString(reader);
        _idleFlee.ReadString(reader);
        _painBodyMinor.ReadString(reader);
        _painBodyMajor.ReadString(reader);
        _painShield.ReadString(reader);
        _painFalling.ReadString(reader);
        _screamFear.ReadString(reader);
        _screamPain.ReadString(reader);
        _maimedLimb.ReadString(reader);
        _maimedHead.ReadString(reader);
        _deathQuiet.ReadString(reader);
        _deathViolent.ReadString(reader);
        _deathFalling.ReadString(reader);
        _deathAgonizing.ReadString(reader);
        _deathInstant.ReadString(reader);
        _deathFlying.ReadString(reader);
        _damagedFriend.ReadString(reader);
        _damagedFriendPlayer.ReadString(reader);
        _damagedEnemy.ReadString(reader);
        _damagedEnemyCm.ReadString(reader);
        _hurtFriend.ReadString(reader);
        _hurtFriendRe.ReadString(reader);
        _hurtFriendPlayer.ReadString(reader);
        _hurtEnemy.ReadString(reader);
        _hurtEnemyRe.ReadString(reader);
        _hurtEnemyCm.ReadString(reader);
        _hurtEnemyBullet.ReadString(reader);
        _hurtEnemyNeedler.ReadString(reader);
        _hurtEnemyPlasma.ReadString(reader);
        _hurtEnemySniper.ReadString(reader);
        _hurtEnemyGrenade.ReadString(reader);
        _hurtEnemyExplosion.ReadString(reader);
        _hurtEnemyMelee.ReadString(reader);
        _hurtEnemyFlame.ReadString(reader);
        _hurtEnemyShotgun.ReadString(reader);
        _hurtEnemyVehicle.ReadString(reader);
        _hurtEnemyMountedweapon.ReadString(reader);
        _killedFriend.ReadString(reader);
        _killedFriendCm.ReadString(reader);
        _killedFriendPlayer.ReadString(reader);
        _killedFriendPlayerCm.ReadString(reader);
        _killedEnemy.ReadString(reader);
        _killedEnemyCm.ReadString(reader);
        _killedEnemyPlayer.ReadString(reader);
        _killedEnemyPlayerCm.ReadString(reader);
        _killedEnemyCovenant.ReadString(reader);
        _killedEnemyCovenantCm.ReadString(reader);
        _killedEnemyFloodcombat.ReadString(reader);
        _killedEnemyFloodcombatCm.ReadString(reader);
        _killedEnemyFloodcarrier.ReadString(reader);
        _killedEnemyFloodcarrierCm.ReadString(reader);
        _killedEnemySentinel.ReadString(reader);
        _killedEnemySentinelCm.ReadString(reader);
        _killedEnemyBullet.ReadString(reader);
        _killedEnemyNeedler.ReadString(reader);
        _killedEnemyPlasma.ReadString(reader);
        _killedEnemySniper.ReadString(reader);
        _killedEnemyGrenade.ReadString(reader);
        _killedEnemyExplosion.ReadString(reader);
        _killedEnemyMelee.ReadString(reader);
        _killedEnemyFlame.ReadString(reader);
        _killedEnemyShotgun.ReadString(reader);
        _killedEnemyVehicle.ReadString(reader);
        _killedEnemyMountedweapon.ReadString(reader);
        _killingSpree.ReadString(reader);
        _playerKillCm.ReadString(reader);
        _playerKillBulletCm.ReadString(reader);
        _playerKillNeedlerCm.ReadString(reader);
        _playerKillPlasmaCm.ReadString(reader);
        _playerKillSniperCm.ReadString(reader);
        _anyoneKillGrenadeCm.ReadString(reader);
        _playerKillExplosionCm.ReadString(reader);
        _playerKillMeleeCm.ReadString(reader);
        _playerKillFlameCm.ReadString(reader);
        _playerKillShotgunCm.ReadString(reader);
        _playerKillVehicleCm.ReadString(reader);
        _playerKillMountedweaponCm.ReadString(reader);
        _playerKilllingSpreeCm.ReadString(reader);
        _friendDied.ReadString(reader);
        _friendPlayerDied.ReadString(reader);
        _friendKilledByFriend.ReadString(reader);
        _friendKilledByFriendlyPlayer.ReadString(reader);
        _friendKilledByEnemy.ReadString(reader);
        _friendKilledByEnemyPlayer.ReadString(reader);
        _friendKilledByCovenant.ReadString(reader);
        _friendKilledByFlood.ReadString(reader);
        _friendKilledBySentinel.ReadString(reader);
        _friendBetrayed.ReadString(reader);
        _newCombatAlone.ReadString(reader);
        _newEnemyRecentCombat.ReadString(reader);
        _oldEnemySighted.ReadString(reader);
        _unexpectedEnemy.ReadString(reader);
        _deadFriendFound.ReadString(reader);
        _allianceBroken.ReadString(reader);
        _allianceReformed.ReadString(reader);
        _grenadeThrowing.ReadString(reader);
        _grenadeSighted.ReadString(reader);
        _grenadeStartle.ReadString(reader);
        _grenadeDangerEnemy.ReadString(reader);
        _grenadeDangerSelf.ReadString(reader);
        _grenadeDangerFriend.ReadString(reader);
        _newCombatGroupRe.ReadString(reader);
        _newCombatNearbyRe.ReadString(reader);
        _alertFriend.ReadString(reader);
        _alertFriendRe.ReadString(reader);
        _alertLostContact.ReadString(reader);
        _alertLostContactRe.ReadString(reader);
        _blocked.ReadString(reader);
        _blockedRe.ReadString(reader);
        _searchStart.ReadString(reader);
        _searchQuery.ReadString(reader);
        _searchQueryRe.ReadString(reader);
        _searchReport.ReadString(reader);
        _searchAbandon.ReadString(reader);
        _searchGroupAbandon.ReadString(reader);
        _groupUncover.ReadString(reader);
        _groupUncoverRe.ReadString(reader);
        _advance.ReadString(reader);
        _advanceRe.ReadString(reader);
        _retreat.ReadString(reader);
        _retreatRe.ReadString(reader);
        _cover.ReadString(reader);
        _sightedFriendPlayer.ReadString(reader);
        _shooting.ReadString(reader);
        _shootingVehicle.ReadString(reader);
        _shootingBerserk.ReadString(reader);
        _shootingGroup.ReadString(reader);
        _shootingTraitor.ReadString(reader);
        _taunt.ReadString(reader);
        _tauntRe.ReadString(reader);
        _flee.ReadString(reader);
        _fleeRe.ReadString(reader);
        _fleeLeaderDied.ReadString(reader);
        _attemptedFlee.ReadString(reader);
        _attemptedFleeRe.ReadString(reader);
        _lostContact.ReadString(reader);
        _hidingFinished.ReadString(reader);
        _vehicleEntry.ReadString(reader);
        _vehicleExit.ReadString(reader);
        _vehicleWoohoo.ReadString(reader);
        _vehicleScared.ReadString(reader);
        _vehicleCollision.ReadString(reader);
        _partiallySighted.ReadString(reader);
        _nothingThere.ReadString(reader);
        _pleading.ReadString(reader);
        _surprise.ReadString(reader);
        _berserk.ReadString(reader);
        _meleeAttack.ReadString(reader);
        _dive.ReadString(reader);
        _uncoverExclamation.ReadString(reader);
        _leapAttack.ReadString(reader);
        _resurrection.ReadString(reader);
        _celebration.ReadString(reader);
        _checkBodyEnemy.ReadString(reader);
        _checkBodyFriend.ReadString(reader);
        _shootingDeadEnemy.ReadString(reader);
        _shootingDeadEnemyPlayer.ReadString(reader);
        _alone.ReadString(reader);
        _unscathed.ReadString(reader);
        _seriouslyWounded.ReadString(reader);
        _seriouslyWoundedRe.ReadString(reader);
        _massacre.ReadString(reader);
        _massacreRe.ReadString(reader);
        _rout.ReadString(reader);
        _routRe.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _idleNoncombat.Write(bw);
        _idleCombat.Write(bw);
        _idleFlee.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _painBodyMinor.Write(bw);
        _painBodyMajor.Write(bw);
        _painShield.Write(bw);
        _painFalling.Write(bw);
        _screamFear.Write(bw);
        _screamPain.Write(bw);
        _maimedLimb.Write(bw);
        _maimedHead.Write(bw);
        _deathQuiet.Write(bw);
        _deathViolent.Write(bw);
        _deathFalling.Write(bw);
        _deathAgonizing.Write(bw);
        _deathInstant.Write(bw);
        _deathFlying.Write(bw);
        _unnamed7.Write(bw);
        _damagedFriend.Write(bw);
        _damagedFriendPlayer.Write(bw);
        _damagedEnemy.Write(bw);
        _damagedEnemyCm.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _hurtFriend.Write(bw);
        _hurtFriendRe.Write(bw);
        _hurtFriendPlayer.Write(bw);
        _hurtEnemy.Write(bw);
        _hurtEnemyRe.Write(bw);
        _hurtEnemyCm.Write(bw);
        _hurtEnemyBullet.Write(bw);
        _hurtEnemyNeedler.Write(bw);
        _hurtEnemyPlasma.Write(bw);
        _hurtEnemySniper.Write(bw);
        _hurtEnemyGrenade.Write(bw);
        _hurtEnemyExplosion.Write(bw);
        _hurtEnemyMelee.Write(bw);
        _hurtEnemyFlame.Write(bw);
        _hurtEnemyShotgun.Write(bw);
        _hurtEnemyVehicle.Write(bw);
        _hurtEnemyMountedweapon.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _killedFriend.Write(bw);
        _killedFriendCm.Write(bw);
        _killedFriendPlayer.Write(bw);
        _killedFriendPlayerCm.Write(bw);
        _killedEnemy.Write(bw);
        _killedEnemyCm.Write(bw);
        _killedEnemyPlayer.Write(bw);
        _killedEnemyPlayerCm.Write(bw);
        _killedEnemyCovenant.Write(bw);
        _killedEnemyCovenantCm.Write(bw);
        _killedEnemyFloodcombat.Write(bw);
        _killedEnemyFloodcombatCm.Write(bw);
        _killedEnemyFloodcarrier.Write(bw);
        _killedEnemyFloodcarrierCm.Write(bw);
        _killedEnemySentinel.Write(bw);
        _killedEnemySentinelCm.Write(bw);
        _killedEnemyBullet.Write(bw);
        _killedEnemyNeedler.Write(bw);
        _killedEnemyPlasma.Write(bw);
        _killedEnemySniper.Write(bw);
        _killedEnemyGrenade.Write(bw);
        _killedEnemyExplosion.Write(bw);
        _killedEnemyMelee.Write(bw);
        _killedEnemyFlame.Write(bw);
        _killedEnemyShotgun.Write(bw);
        _killedEnemyVehicle.Write(bw);
        _killedEnemyMountedweapon.Write(bw);
        _killingSpree.Write(bw);
        _unnamed15.Write(bw);
        _unnamed16.Write(bw);
        _unnamed17.Write(bw);
        _playerKillCm.Write(bw);
        _playerKillBulletCm.Write(bw);
        _playerKillNeedlerCm.Write(bw);
        _playerKillPlasmaCm.Write(bw);
        _playerKillSniperCm.Write(bw);
        _anyoneKillGrenadeCm.Write(bw);
        _playerKillExplosionCm.Write(bw);
        _playerKillMeleeCm.Write(bw);
        _playerKillFlameCm.Write(bw);
        _playerKillShotgunCm.Write(bw);
        _playerKillVehicleCm.Write(bw);
        _playerKillMountedweaponCm.Write(bw);
        _playerKilllingSpreeCm.Write(bw);
        _unnamed18.Write(bw);
        _unnamed19.Write(bw);
        _unnamed20.Write(bw);
        _friendDied.Write(bw);
        _friendPlayerDied.Write(bw);
        _friendKilledByFriend.Write(bw);
        _friendKilledByFriendlyPlayer.Write(bw);
        _friendKilledByEnemy.Write(bw);
        _friendKilledByEnemyPlayer.Write(bw);
        _friendKilledByCovenant.Write(bw);
        _friendKilledByFlood.Write(bw);
        _friendKilledBySentinel.Write(bw);
        _friendBetrayed.Write(bw);
        _unnamed21.Write(bw);
        _unnamed22.Write(bw);
        _newCombatAlone.Write(bw);
        _newEnemyRecentCombat.Write(bw);
        _oldEnemySighted.Write(bw);
        _unexpectedEnemy.Write(bw);
        _deadFriendFound.Write(bw);
        _allianceBroken.Write(bw);
        _allianceReformed.Write(bw);
        _grenadeThrowing.Write(bw);
        _grenadeSighted.Write(bw);
        _grenadeStartle.Write(bw);
        _grenadeDangerEnemy.Write(bw);
        _grenadeDangerSelf.Write(bw);
        _grenadeDangerFriend.Write(bw);
        _unnamed23.Write(bw);
        _unnamed24.Write(bw);
        _newCombatGroupRe.Write(bw);
        _newCombatNearbyRe.Write(bw);
        _alertFriend.Write(bw);
        _alertFriendRe.Write(bw);
        _alertLostContact.Write(bw);
        _alertLostContactRe.Write(bw);
        _blocked.Write(bw);
        _blockedRe.Write(bw);
        _searchStart.Write(bw);
        _searchQuery.Write(bw);
        _searchQueryRe.Write(bw);
        _searchReport.Write(bw);
        _searchAbandon.Write(bw);
        _searchGroupAbandon.Write(bw);
        _groupUncover.Write(bw);
        _groupUncoverRe.Write(bw);
        _advance.Write(bw);
        _advanceRe.Write(bw);
        _retreat.Write(bw);
        _retreatRe.Write(bw);
        _cover.Write(bw);
        _unnamed25.Write(bw);
        _unnamed26.Write(bw);
        _unnamed27.Write(bw);
        _unnamed28.Write(bw);
        _sightedFriendPlayer.Write(bw);
        _shooting.Write(bw);
        _shootingVehicle.Write(bw);
        _shootingBerserk.Write(bw);
        _shootingGroup.Write(bw);
        _shootingTraitor.Write(bw);
        _taunt.Write(bw);
        _tauntRe.Write(bw);
        _flee.Write(bw);
        _fleeRe.Write(bw);
        _fleeLeaderDied.Write(bw);
        _attemptedFlee.Write(bw);
        _attemptedFleeRe.Write(bw);
        _lostContact.Write(bw);
        _hidingFinished.Write(bw);
        _vehicleEntry.Write(bw);
        _vehicleExit.Write(bw);
        _vehicleWoohoo.Write(bw);
        _vehicleScared.Write(bw);
        _vehicleCollision.Write(bw);
        _partiallySighted.Write(bw);
        _nothingThere.Write(bw);
        _pleading.Write(bw);
        _unnamed29.Write(bw);
        _unnamed30.Write(bw);
        _unnamed31.Write(bw);
        _unnamed32.Write(bw);
        _unnamed33.Write(bw);
        _unnamed34.Write(bw);
        _surprise.Write(bw);
        _berserk.Write(bw);
        _meleeAttack.Write(bw);
        _dive.Write(bw);
        _uncoverExclamation.Write(bw);
        _leapAttack.Write(bw);
        _resurrection.Write(bw);
        _unnamed35.Write(bw);
        _unnamed36.Write(bw);
        _unnamed37.Write(bw);
        _unnamed38.Write(bw);
        _celebration.Write(bw);
        _checkBodyEnemy.Write(bw);
        _checkBodyFriend.Write(bw);
        _shootingDeadEnemy.Write(bw);
        _shootingDeadEnemyPlayer.Write(bw);
        _unnamed39.Write(bw);
        _unnamed40.Write(bw);
        _unnamed41.Write(bw);
        _unnamed42.Write(bw);
        _alone.Write(bw);
        _unscathed.Write(bw);
        _seriouslyWounded.Write(bw);
        _seriouslyWoundedRe.Write(bw);
        _massacre.Write(bw);
        _massacreRe.Write(bw);
        _rout.Write(bw);
        _routRe.Write(bw);
        _unnamed43.Write(bw);
        _unnamed44.Write(bw);
        _unnamed45.Write(bw);
        _unnamed46.Write(bw);
        _unnamed47.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _idleNoncombat.WriteString(writer);
        _idleCombat.WriteString(writer);
        _idleFlee.WriteString(writer);
        _painBodyMinor.WriteString(writer);
        _painBodyMajor.WriteString(writer);
        _painShield.WriteString(writer);
        _painFalling.WriteString(writer);
        _screamFear.WriteString(writer);
        _screamPain.WriteString(writer);
        _maimedLimb.WriteString(writer);
        _maimedHead.WriteString(writer);
        _deathQuiet.WriteString(writer);
        _deathViolent.WriteString(writer);
        _deathFalling.WriteString(writer);
        _deathAgonizing.WriteString(writer);
        _deathInstant.WriteString(writer);
        _deathFlying.WriteString(writer);
        _damagedFriend.WriteString(writer);
        _damagedFriendPlayer.WriteString(writer);
        _damagedEnemy.WriteString(writer);
        _damagedEnemyCm.WriteString(writer);
        _hurtFriend.WriteString(writer);
        _hurtFriendRe.WriteString(writer);
        _hurtFriendPlayer.WriteString(writer);
        _hurtEnemy.WriteString(writer);
        _hurtEnemyRe.WriteString(writer);
        _hurtEnemyCm.WriteString(writer);
        _hurtEnemyBullet.WriteString(writer);
        _hurtEnemyNeedler.WriteString(writer);
        _hurtEnemyPlasma.WriteString(writer);
        _hurtEnemySniper.WriteString(writer);
        _hurtEnemyGrenade.WriteString(writer);
        _hurtEnemyExplosion.WriteString(writer);
        _hurtEnemyMelee.WriteString(writer);
        _hurtEnemyFlame.WriteString(writer);
        _hurtEnemyShotgun.WriteString(writer);
        _hurtEnemyVehicle.WriteString(writer);
        _hurtEnemyMountedweapon.WriteString(writer);
        _killedFriend.WriteString(writer);
        _killedFriendCm.WriteString(writer);
        _killedFriendPlayer.WriteString(writer);
        _killedFriendPlayerCm.WriteString(writer);
        _killedEnemy.WriteString(writer);
        _killedEnemyCm.WriteString(writer);
        _killedEnemyPlayer.WriteString(writer);
        _killedEnemyPlayerCm.WriteString(writer);
        _killedEnemyCovenant.WriteString(writer);
        _killedEnemyCovenantCm.WriteString(writer);
        _killedEnemyFloodcombat.WriteString(writer);
        _killedEnemyFloodcombatCm.WriteString(writer);
        _killedEnemyFloodcarrier.WriteString(writer);
        _killedEnemyFloodcarrierCm.WriteString(writer);
        _killedEnemySentinel.WriteString(writer);
        _killedEnemySentinelCm.WriteString(writer);
        _killedEnemyBullet.WriteString(writer);
        _killedEnemyNeedler.WriteString(writer);
        _killedEnemyPlasma.WriteString(writer);
        _killedEnemySniper.WriteString(writer);
        _killedEnemyGrenade.WriteString(writer);
        _killedEnemyExplosion.WriteString(writer);
        _killedEnemyMelee.WriteString(writer);
        _killedEnemyFlame.WriteString(writer);
        _killedEnemyShotgun.WriteString(writer);
        _killedEnemyVehicle.WriteString(writer);
        _killedEnemyMountedweapon.WriteString(writer);
        _killingSpree.WriteString(writer);
        _playerKillCm.WriteString(writer);
        _playerKillBulletCm.WriteString(writer);
        _playerKillNeedlerCm.WriteString(writer);
        _playerKillPlasmaCm.WriteString(writer);
        _playerKillSniperCm.WriteString(writer);
        _anyoneKillGrenadeCm.WriteString(writer);
        _playerKillExplosionCm.WriteString(writer);
        _playerKillMeleeCm.WriteString(writer);
        _playerKillFlameCm.WriteString(writer);
        _playerKillShotgunCm.WriteString(writer);
        _playerKillVehicleCm.WriteString(writer);
        _playerKillMountedweaponCm.WriteString(writer);
        _playerKilllingSpreeCm.WriteString(writer);
        _friendDied.WriteString(writer);
        _friendPlayerDied.WriteString(writer);
        _friendKilledByFriend.WriteString(writer);
        _friendKilledByFriendlyPlayer.WriteString(writer);
        _friendKilledByEnemy.WriteString(writer);
        _friendKilledByEnemyPlayer.WriteString(writer);
        _friendKilledByCovenant.WriteString(writer);
        _friendKilledByFlood.WriteString(writer);
        _friendKilledBySentinel.WriteString(writer);
        _friendBetrayed.WriteString(writer);
        _newCombatAlone.WriteString(writer);
        _newEnemyRecentCombat.WriteString(writer);
        _oldEnemySighted.WriteString(writer);
        _unexpectedEnemy.WriteString(writer);
        _deadFriendFound.WriteString(writer);
        _allianceBroken.WriteString(writer);
        _allianceReformed.WriteString(writer);
        _grenadeThrowing.WriteString(writer);
        _grenadeSighted.WriteString(writer);
        _grenadeStartle.WriteString(writer);
        _grenadeDangerEnemy.WriteString(writer);
        _grenadeDangerSelf.WriteString(writer);
        _grenadeDangerFriend.WriteString(writer);
        _newCombatGroupRe.WriteString(writer);
        _newCombatNearbyRe.WriteString(writer);
        _alertFriend.WriteString(writer);
        _alertFriendRe.WriteString(writer);
        _alertLostContact.WriteString(writer);
        _alertLostContactRe.WriteString(writer);
        _blocked.WriteString(writer);
        _blockedRe.WriteString(writer);
        _searchStart.WriteString(writer);
        _searchQuery.WriteString(writer);
        _searchQueryRe.WriteString(writer);
        _searchReport.WriteString(writer);
        _searchAbandon.WriteString(writer);
        _searchGroupAbandon.WriteString(writer);
        _groupUncover.WriteString(writer);
        _groupUncoverRe.WriteString(writer);
        _advance.WriteString(writer);
        _advanceRe.WriteString(writer);
        _retreat.WriteString(writer);
        _retreatRe.WriteString(writer);
        _cover.WriteString(writer);
        _sightedFriendPlayer.WriteString(writer);
        _shooting.WriteString(writer);
        _shootingVehicle.WriteString(writer);
        _shootingBerserk.WriteString(writer);
        _shootingGroup.WriteString(writer);
        _shootingTraitor.WriteString(writer);
        _taunt.WriteString(writer);
        _tauntRe.WriteString(writer);
        _flee.WriteString(writer);
        _fleeRe.WriteString(writer);
        _fleeLeaderDied.WriteString(writer);
        _attemptedFlee.WriteString(writer);
        _attemptedFleeRe.WriteString(writer);
        _lostContact.WriteString(writer);
        _hidingFinished.WriteString(writer);
        _vehicleEntry.WriteString(writer);
        _vehicleExit.WriteString(writer);
        _vehicleWoohoo.WriteString(writer);
        _vehicleScared.WriteString(writer);
        _vehicleCollision.WriteString(writer);
        _partiallySighted.WriteString(writer);
        _nothingThere.WriteString(writer);
        _pleading.WriteString(writer);
        _surprise.WriteString(writer);
        _berserk.WriteString(writer);
        _meleeAttack.WriteString(writer);
        _dive.WriteString(writer);
        _uncoverExclamation.WriteString(writer);
        _leapAttack.WriteString(writer);
        _resurrection.WriteString(writer);
        _celebration.WriteString(writer);
        _checkBodyEnemy.WriteString(writer);
        _checkBodyFriend.WriteString(writer);
        _shootingDeadEnemy.WriteString(writer);
        _shootingDeadEnemyPlayer.WriteString(writer);
        _alone.WriteString(writer);
        _unscathed.WriteString(writer);
        _seriouslyWounded.WriteString(writer);
        _seriouslyWoundedRe.WriteString(writer);
        _massacre.WriteString(writer);
        _massacreRe.WriteString(writer);
        _rout.WriteString(writer);
        _routRe.WriteString(writer);
      }
    }
  }
}
