// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'continuous_damage_effect'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class continuous_damage_effect : Interfaces.Pool.Tag {
    private ContinuousDamageEffectBlock continuousDamageEffectValues = new ContinuousDamageEffectBlock();
    public virtual ContinuousDamageEffectBlock ContinuousDamageEffectValues {
      get {
        return continuousDamageEffectValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ContinuousDamageEffectValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "continuous_damage_effect";
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
continuousDamageEffectValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
continuousDamageEffectValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
continuousDamageEffectValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
continuousDamageEffectValues.WriteChildData(writer);
    }
    #endregion
    public class ContinuousDamageEffectBlock : IBlock {
      private RealBounds _radius = new RealBounds();
      private RealFraction _cutoffScale = new RealFraction();
      private Pad _unnamed;
      private RealFraction _lowFrequency = new RealFraction();
      private RealFraction _highFrequency = new RealFraction();
      private Pad _unnamed2;
      private Real _randomTranslation = new Real();
      private Angle _randomRotation = new Angle();
      private Pad _unnamed3;
      private Enum _wobbleFunction = new Enum();
      private Pad _unnamed4;
      private Real _wobbleFunctionPeriod = new Real();
      private RealFraction _wobbleWeight = new RealFraction();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Enum _sideEffect = new Enum();
      private Enum _category = new Enum();
      private Flags _flags;
      private Pad _unnamed9;
      private Real _damageLowerBound = new Real();
      private RealBounds _damageUpperBound = new RealBounds();
      private Real _vehiclePassthroughPenalty = new Real();
      private Pad _unnamed10;
      private Real _stun = new Real();
      private Real _maximumStun = new Real();
      private Real _stunTime = new Real();
      private Pad _unnamed11;
      private Real _instantaneousAcceleration = new Real();
      private Pad _unnamed12;
      private Pad _unnamed13;
      private Real _dirt = new Real();
      private Real _sand = new Real();
      private Real _stone = new Real();
      private Real _snow = new Real();
      private Real _wood = new Real();
      private Real _metalHollow = new Real();
      private Real _metalThin = new Real();
      private Real _metalThick = new Real();
      private Real _rubber = new Real();
      private Real _glass = new Real();
      private Real _forceField = new Real();
      private Real _grunt = new Real();
      private Real _hunterArmor = new Real();
      private Real _hunterSkin = new Real();
      private Real _elite = new Real();
      private Real _jackal = new Real();
      private Real _jackalEnergyShield = new Real();
      private Real _engineer = new Real();
      private Real _engineerForceField = new Real();
      private Real _floodCombatForm = new Real();
      private Real _floodCarrierForm = new Real();
      private Real _cyborg = new Real();
      private Real _cyborgEnergyShield = new Real();
      private Real _armoredHuman = new Real();
      private Real _human = new Real();
      private Real _sentinel = new Real();
      private Real _monitor = new Real();
      private Real _plastic = new Real();
      private Real _water = new Real();
      private Real _leaves = new Real();
      private Real _eliteEnergyShield = new Real();
      private Real _ice = new Real();
      private Real _hunterShield = new Real();
      private Pad _unnamed14;
public event System.EventHandler BlockNameChanged;
      public ContinuousDamageEffectBlock() {
        this._unnamed = new Pad(24);
        this._unnamed2 = new Pad(24);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(20);
        this._unnamed7 = new Pad(8);
        this._unnamed8 = new Pad(160);
        this._flags = new Flags(4);
        this._unnamed9 = new Pad(4);
        this._unnamed10 = new Pad(4);
        this._unnamed11 = new Pad(4);
        this._unnamed12 = new Pad(4);
        this._unnamed13 = new Pad(4);
        this._unnamed14 = new Pad(28);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealBounds Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public RealFraction CutoffScale {
        get {
          return this._cutoffScale;
        }
        set {
          this._cutoffScale = value;
        }
      }
      public RealFraction LowFrequency {
        get {
          return this._lowFrequency;
        }
        set {
          this._lowFrequency = value;
        }
      }
      public RealFraction HighFrequency {
        get {
          return this._highFrequency;
        }
        set {
          this._highFrequency = value;
        }
      }
      public Real RandomTranslation {
        get {
          return this._randomTranslation;
        }
        set {
          this._randomTranslation = value;
        }
      }
      public Angle RandomRotation {
        get {
          return this._randomRotation;
        }
        set {
          this._randomRotation = value;
        }
      }
      public Enum WobbleFunction {
        get {
          return this._wobbleFunction;
        }
        set {
          this._wobbleFunction = value;
        }
      }
      public Real WobbleFunctionPeriod {
        get {
          return this._wobbleFunctionPeriod;
        }
        set {
          this._wobbleFunctionPeriod = value;
        }
      }
      public RealFraction WobbleWeight {
        get {
          return this._wobbleWeight;
        }
        set {
          this._wobbleWeight = value;
        }
      }
      public Enum SideEffect {
        get {
          return this._sideEffect;
        }
        set {
          this._sideEffect = value;
        }
      }
      public Enum Category {
        get {
          return this._category;
        }
        set {
          this._category = value;
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
      public Real DamageLowerBound {
        get {
          return this._damageLowerBound;
        }
        set {
          this._damageLowerBound = value;
        }
      }
      public RealBounds DamageUpperBound {
        get {
          return this._damageUpperBound;
        }
        set {
          this._damageUpperBound = value;
        }
      }
      public Real VehiclePassthroughPenalty {
        get {
          return this._vehiclePassthroughPenalty;
        }
        set {
          this._vehiclePassthroughPenalty = value;
        }
      }
      public Real Stun {
        get {
          return this._stun;
        }
        set {
          this._stun = value;
        }
      }
      public Real MaximumStun {
        get {
          return this._maximumStun;
        }
        set {
          this._maximumStun = value;
        }
      }
      public Real StunTime {
        get {
          return this._stunTime;
        }
        set {
          this._stunTime = value;
        }
      }
      public Real InstantaneousAcceleration {
        get {
          return this._instantaneousAcceleration;
        }
        set {
          this._instantaneousAcceleration = value;
        }
      }
      public Real Dirt {
        get {
          return this._dirt;
        }
        set {
          this._dirt = value;
        }
      }
      public Real Sand {
        get {
          return this._sand;
        }
        set {
          this._sand = value;
        }
      }
      public Real Stone {
        get {
          return this._stone;
        }
        set {
          this._stone = value;
        }
      }
      public Real Snow {
        get {
          return this._snow;
        }
        set {
          this._snow = value;
        }
      }
      public Real Wood {
        get {
          return this._wood;
        }
        set {
          this._wood = value;
        }
      }
      public Real MetalHollow {
        get {
          return this._metalHollow;
        }
        set {
          this._metalHollow = value;
        }
      }
      public Real MetalThin {
        get {
          return this._metalThin;
        }
        set {
          this._metalThin = value;
        }
      }
      public Real MetalThick {
        get {
          return this._metalThick;
        }
        set {
          this._metalThick = value;
        }
      }
      public Real Rubber {
        get {
          return this._rubber;
        }
        set {
          this._rubber = value;
        }
      }
      public Real Glass {
        get {
          return this._glass;
        }
        set {
          this._glass = value;
        }
      }
      public Real ForceField {
        get {
          return this._forceField;
        }
        set {
          this._forceField = value;
        }
      }
      public Real Grunt {
        get {
          return this._grunt;
        }
        set {
          this._grunt = value;
        }
      }
      public Real HunterArmor {
        get {
          return this._hunterArmor;
        }
        set {
          this._hunterArmor = value;
        }
      }
      public Real HunterSkin {
        get {
          return this._hunterSkin;
        }
        set {
          this._hunterSkin = value;
        }
      }
      public Real Elite {
        get {
          return this._elite;
        }
        set {
          this._elite = value;
        }
      }
      public Real Jackal {
        get {
          return this._jackal;
        }
        set {
          this._jackal = value;
        }
      }
      public Real JackalEnergyShield {
        get {
          return this._jackalEnergyShield;
        }
        set {
          this._jackalEnergyShield = value;
        }
      }
      public Real Engineer {
        get {
          return this._engineer;
        }
        set {
          this._engineer = value;
        }
      }
      public Real EngineerForceField {
        get {
          return this._engineerForceField;
        }
        set {
          this._engineerForceField = value;
        }
      }
      public Real FloodCombatForm {
        get {
          return this._floodCombatForm;
        }
        set {
          this._floodCombatForm = value;
        }
      }
      public Real FloodCarrierForm {
        get {
          return this._floodCarrierForm;
        }
        set {
          this._floodCarrierForm = value;
        }
      }
      public Real Cyborg {
        get {
          return this._cyborg;
        }
        set {
          this._cyborg = value;
        }
      }
      public Real CyborgEnergyShield {
        get {
          return this._cyborgEnergyShield;
        }
        set {
          this._cyborgEnergyShield = value;
        }
      }
      public Real ArmoredHuman {
        get {
          return this._armoredHuman;
        }
        set {
          this._armoredHuman = value;
        }
      }
      public Real Human {
        get {
          return this._human;
        }
        set {
          this._human = value;
        }
      }
      public Real Sentinel {
        get {
          return this._sentinel;
        }
        set {
          this._sentinel = value;
        }
      }
      public Real Monitor {
        get {
          return this._monitor;
        }
        set {
          this._monitor = value;
        }
      }
      public Real Plastic {
        get {
          return this._plastic;
        }
        set {
          this._plastic = value;
        }
      }
      public Real Water {
        get {
          return this._water;
        }
        set {
          this._water = value;
        }
      }
      public Real Leaves {
        get {
          return this._leaves;
        }
        set {
          this._leaves = value;
        }
      }
      public Real EliteEnergyShield {
        get {
          return this._eliteEnergyShield;
        }
        set {
          this._eliteEnergyShield = value;
        }
      }
      public Real Ice {
        get {
          return this._ice;
        }
        set {
          this._ice = value;
        }
      }
      public Real HunterShield {
        get {
          return this._hunterShield;
        }
        set {
          this._hunterShield = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _radius.Read(reader);
        _cutoffScale.Read(reader);
        _unnamed.Read(reader);
        _lowFrequency.Read(reader);
        _highFrequency.Read(reader);
        _unnamed2.Read(reader);
        _randomTranslation.Read(reader);
        _randomRotation.Read(reader);
        _unnamed3.Read(reader);
        _wobbleFunction.Read(reader);
        _unnamed4.Read(reader);
        _wobbleFunctionPeriod.Read(reader);
        _wobbleWeight.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _sideEffect.Read(reader);
        _category.Read(reader);
        _flags.Read(reader);
        _unnamed9.Read(reader);
        _damageLowerBound.Read(reader);
        _damageUpperBound.Read(reader);
        _vehiclePassthroughPenalty.Read(reader);
        _unnamed10.Read(reader);
        _stun.Read(reader);
        _maximumStun.Read(reader);
        _stunTime.Read(reader);
        _unnamed11.Read(reader);
        _instantaneousAcceleration.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _dirt.Read(reader);
        _sand.Read(reader);
        _stone.Read(reader);
        _snow.Read(reader);
        _wood.Read(reader);
        _metalHollow.Read(reader);
        _metalThin.Read(reader);
        _metalThick.Read(reader);
        _rubber.Read(reader);
        _glass.Read(reader);
        _forceField.Read(reader);
        _grunt.Read(reader);
        _hunterArmor.Read(reader);
        _hunterSkin.Read(reader);
        _elite.Read(reader);
        _jackal.Read(reader);
        _jackalEnergyShield.Read(reader);
        _engineer.Read(reader);
        _engineerForceField.Read(reader);
        _floodCombatForm.Read(reader);
        _floodCarrierForm.Read(reader);
        _cyborg.Read(reader);
        _cyborgEnergyShield.Read(reader);
        _armoredHuman.Read(reader);
        _human.Read(reader);
        _sentinel.Read(reader);
        _monitor.Read(reader);
        _plastic.Read(reader);
        _water.Read(reader);
        _leaves.Read(reader);
        _eliteEnergyShield.Read(reader);
        _ice.Read(reader);
        _hunterShield.Read(reader);
        _unnamed14.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _radius.Write(bw);
        _cutoffScale.Write(bw);
        _unnamed.Write(bw);
        _lowFrequency.Write(bw);
        _highFrequency.Write(bw);
        _unnamed2.Write(bw);
        _randomTranslation.Write(bw);
        _randomRotation.Write(bw);
        _unnamed3.Write(bw);
        _wobbleFunction.Write(bw);
        _unnamed4.Write(bw);
        _wobbleFunctionPeriod.Write(bw);
        _wobbleWeight.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _sideEffect.Write(bw);
        _category.Write(bw);
        _flags.Write(bw);
        _unnamed9.Write(bw);
        _damageLowerBound.Write(bw);
        _damageUpperBound.Write(bw);
        _vehiclePassthroughPenalty.Write(bw);
        _unnamed10.Write(bw);
        _stun.Write(bw);
        _maximumStun.Write(bw);
        _stunTime.Write(bw);
        _unnamed11.Write(bw);
        _instantaneousAcceleration.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _dirt.Write(bw);
        _sand.Write(bw);
        _stone.Write(bw);
        _snow.Write(bw);
        _wood.Write(bw);
        _metalHollow.Write(bw);
        _metalThin.Write(bw);
        _metalThick.Write(bw);
        _rubber.Write(bw);
        _glass.Write(bw);
        _forceField.Write(bw);
        _grunt.Write(bw);
        _hunterArmor.Write(bw);
        _hunterSkin.Write(bw);
        _elite.Write(bw);
        _jackal.Write(bw);
        _jackalEnergyShield.Write(bw);
        _engineer.Write(bw);
        _engineerForceField.Write(bw);
        _floodCombatForm.Write(bw);
        _floodCarrierForm.Write(bw);
        _cyborg.Write(bw);
        _cyborgEnergyShield.Write(bw);
        _armoredHuman.Write(bw);
        _human.Write(bw);
        _sentinel.Write(bw);
        _monitor.Write(bw);
        _plastic.Write(bw);
        _water.Write(bw);
        _leaves.Write(bw);
        _eliteEnergyShield.Write(bw);
        _ice.Write(bw);
        _hunterShield.Write(bw);
        _unnamed14.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
