// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'damage_effect'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class damage_effect : Interfaces.Pool.Tag {
    private DamageEffectBlock damageEffectValues = new DamageEffectBlock();
    public virtual DamageEffectBlock DamageEffectValues {
      get {
        return damageEffectValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(DamageEffectValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "damage_effect";
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
damageEffectValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
damageEffectValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
damageEffectValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
damageEffectValues.WriteChildData(writer);
    }
    #endregion
    public class DamageEffectBlock : IBlock {
      private RealBounds _radius = new RealBounds();
      private RealFraction _cutoffScale = new RealFraction();
      private Flags _flags;
      private Pad _unnamed;
      private Enum _type = new Enum();
      private Enum _priority = new Enum();
      private Pad _unnamed2;
      private Real _duration = new Real();
      private Enum _fadeFunction = new Enum();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private RealFraction _maximumIntensity = new RealFraction();
      private Pad _unnamed5;
      private RealARGBColor _color = new RealARGBColor();
      private RealFraction _frequency = new RealFraction();
      private Real _duration2 = new Real();
      private Enum _fadeFunction2 = new Enum();
      private Pad _unnamed6;
      private Pad _unnamed7;
      private RealFraction _frequency2 = new RealFraction();
      private Real _duration3 = new Real();
      private Enum _fadeFunction3 = new Enum();
      private Pad _unnamed8;
      private Pad _unnamed9;
      private Pad _unnamed10;
      private Pad _unnamed11;
      private Real _duration4 = new Real();
      private Enum _fadeFunction4 = new Enum();
      private Pad _unnamed12;
      private Angle _rotation = new Angle();
      private Real _pushback = new Real();
      private RealBounds _jitter = new RealBounds();
      private Pad _unnamed13;
      private Pad _unnamed14;
      private Angle _angle = new Angle();
      private Pad _unnamed15;
      private Pad _unnamed16;
      private Real _duration5 = new Real();
      private Enum _falloffFunction = new Enum();
      private Pad _unnamed17;
      private Real _randomTranslation = new Real();
      private Angle _randomRotation = new Angle();
      private Pad _unnamed18;
      private Enum _wobbleFunction = new Enum();
      private Pad _unnamed19;
      private Real _wobbleFunctionPeriod = new Real();
      private RealFraction _wobbleWeight = new RealFraction();
      private Pad _unnamed20;
      private Pad _unnamed21;
      private Pad _unnamed22;
      private TagReference _sound = new TagReference();
      private Pad _unnamed23;
      private Real _forwardVelocity = new Real();
      private Real _forwardRadius = new Real();
      private Real _forwardExponent = new Real();
      private Pad _unnamed24;
      private Real _outwardVelocity = new Real();
      private Real _outwardRadius = new Real();
      private Real _outwardExponent = new Real();
      private Pad _unnamed25;
      private Enum _sideEffect = new Enum();
      private Enum _category = new Enum();
      private Flags _flags2;
      private Real _aOECoreRadius = new Real();
      private Real _damageLowerBound = new Real();
      private RealBounds _damageUpperBound = new RealBounds();
      private Real _vehiclePassthroughPenalty = new Real();
      private Real _activeCamouflageDamage = new Real();
      private Real _stun = new Real();
      private Real _maximumStun = new Real();
      private Real _stunTime = new Real();
      private Pad _unnamed26;
      private Real _instantaneousAcceleration = new Real();
      private Pad _unnamed27;
      private Pad _unnamed28;
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
      private Pad _unnamed29;
public event System.EventHandler BlockNameChanged;
      public DamageEffectBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(20);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(8);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(8);
        this._unnamed8 = new Pad(2);
        this._unnamed9 = new Pad(8);
        this._unnamed10 = new Pad(4);
        this._unnamed11 = new Pad(16);
        this._unnamed12 = new Pad(2);
        this._unnamed13 = new Pad(4);
        this._unnamed14 = new Pad(4);
        this._unnamed15 = new Pad(4);
        this._unnamed16 = new Pad(12);
        this._unnamed17 = new Pad(2);
        this._unnamed18 = new Pad(12);
        this._unnamed19 = new Pad(2);
        this._unnamed20 = new Pad(4);
        this._unnamed21 = new Pad(20);
        this._unnamed22 = new Pad(8);
        this._unnamed23 = new Pad(112);
        this._unnamed24 = new Pad(12);
        this._unnamed25 = new Pad(12);
        this._flags2 = new Flags(4);
        this._unnamed26 = new Pad(4);
        this._unnamed27 = new Pad(4);
        this._unnamed28 = new Pad(4);
        this._unnamed29 = new Pad(28);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
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
      public Enum Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
        }
      }
      public Real Duration {
        get {
          return this._duration;
        }
        set {
          this._duration = value;
        }
      }
      public Enum FadeFunction {
        get {
          return this._fadeFunction;
        }
        set {
          this._fadeFunction = value;
        }
      }
      public RealFraction MaximumIntensity {
        get {
          return this._maximumIntensity;
        }
        set {
          this._maximumIntensity = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public RealFraction Frequency {
        get {
          return this._frequency;
        }
        set {
          this._frequency = value;
        }
      }
      public Real Duration2 {
        get {
          return this._duration2;
        }
        set {
          this._duration2 = value;
        }
      }
      public Enum FadeFunction2 {
        get {
          return this._fadeFunction2;
        }
        set {
          this._fadeFunction2 = value;
        }
      }
      public RealFraction Frequency2 {
        get {
          return this._frequency2;
        }
        set {
          this._frequency2 = value;
        }
      }
      public Real Duration3 {
        get {
          return this._duration3;
        }
        set {
          this._duration3 = value;
        }
      }
      public Enum FadeFunction3 {
        get {
          return this._fadeFunction3;
        }
        set {
          this._fadeFunction3 = value;
        }
      }
      public Real Duration4 {
        get {
          return this._duration4;
        }
        set {
          this._duration4 = value;
        }
      }
      public Enum FadeFunction4 {
        get {
          return this._fadeFunction4;
        }
        set {
          this._fadeFunction4 = value;
        }
      }
      public Angle Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public Real Pushback {
        get {
          return this._pushback;
        }
        set {
          this._pushback = value;
        }
      }
      public RealBounds Jitter {
        get {
          return this._jitter;
        }
        set {
          this._jitter = value;
        }
      }
      public Angle Angle {
        get {
          return this._angle;
        }
        set {
          this._angle = value;
        }
      }
      public Real Duration5 {
        get {
          return this._duration5;
        }
        set {
          this._duration5 = value;
        }
      }
      public Enum FalloffFunction {
        get {
          return this._falloffFunction;
        }
        set {
          this._falloffFunction = value;
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
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public Real ForwardVelocity {
        get {
          return this._forwardVelocity;
        }
        set {
          this._forwardVelocity = value;
        }
      }
      public Real ForwardRadius {
        get {
          return this._forwardRadius;
        }
        set {
          this._forwardRadius = value;
        }
      }
      public Real ForwardExponent {
        get {
          return this._forwardExponent;
        }
        set {
          this._forwardExponent = value;
        }
      }
      public Real OutwardVelocity {
        get {
          return this._outwardVelocity;
        }
        set {
          this._outwardVelocity = value;
        }
      }
      public Real OutwardRadius {
        get {
          return this._outwardRadius;
        }
        set {
          this._outwardRadius = value;
        }
      }
      public Real OutwardExponent {
        get {
          return this._outwardExponent;
        }
        set {
          this._outwardExponent = value;
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
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
        }
      }
      public Real AOECoreRadius {
        get {
          return this._aOECoreRadius;
        }
        set {
          this._aOECoreRadius = value;
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
      public Real ActiveCamouflageDamage {
        get {
          return this._activeCamouflageDamage;
        }
        set {
          this._activeCamouflageDamage = value;
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
        _flags.Read(reader);
        _unnamed.Read(reader);
        _type.Read(reader);
        _priority.Read(reader);
        _unnamed2.Read(reader);
        _duration.Read(reader);
        _fadeFunction.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _maximumIntensity.Read(reader);
        _unnamed5.Read(reader);
        _color.Read(reader);
        _frequency.Read(reader);
        _duration2.Read(reader);
        _fadeFunction2.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _frequency2.Read(reader);
        _duration3.Read(reader);
        _fadeFunction3.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _duration4.Read(reader);
        _fadeFunction4.Read(reader);
        _unnamed12.Read(reader);
        _rotation.Read(reader);
        _pushback.Read(reader);
        _jitter.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _angle.Read(reader);
        _unnamed15.Read(reader);
        _unnamed16.Read(reader);
        _duration5.Read(reader);
        _falloffFunction.Read(reader);
        _unnamed17.Read(reader);
        _randomTranslation.Read(reader);
        _randomRotation.Read(reader);
        _unnamed18.Read(reader);
        _wobbleFunction.Read(reader);
        _unnamed19.Read(reader);
        _wobbleFunctionPeriod.Read(reader);
        _wobbleWeight.Read(reader);
        _unnamed20.Read(reader);
        _unnamed21.Read(reader);
        _unnamed22.Read(reader);
        _sound.Read(reader);
        _unnamed23.Read(reader);
        _forwardVelocity.Read(reader);
        _forwardRadius.Read(reader);
        _forwardExponent.Read(reader);
        _unnamed24.Read(reader);
        _outwardVelocity.Read(reader);
        _outwardRadius.Read(reader);
        _outwardExponent.Read(reader);
        _unnamed25.Read(reader);
        _sideEffect.Read(reader);
        _category.Read(reader);
        _flags2.Read(reader);
        _aOECoreRadius.Read(reader);
        _damageLowerBound.Read(reader);
        _damageUpperBound.Read(reader);
        _vehiclePassthroughPenalty.Read(reader);
        _activeCamouflageDamage.Read(reader);
        _stun.Read(reader);
        _maximumStun.Read(reader);
        _stunTime.Read(reader);
        _unnamed26.Read(reader);
        _instantaneousAcceleration.Read(reader);
        _unnamed27.Read(reader);
        _unnamed28.Read(reader);
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
        _unnamed29.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _radius.Write(bw);
        _cutoffScale.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _type.Write(bw);
        _priority.Write(bw);
        _unnamed2.Write(bw);
        _duration.Write(bw);
        _fadeFunction.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _maximumIntensity.Write(bw);
        _unnamed5.Write(bw);
        _color.Write(bw);
        _frequency.Write(bw);
        _duration2.Write(bw);
        _fadeFunction2.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _frequency2.Write(bw);
        _duration3.Write(bw);
        _fadeFunction3.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _duration4.Write(bw);
        _fadeFunction4.Write(bw);
        _unnamed12.Write(bw);
        _rotation.Write(bw);
        _pushback.Write(bw);
        _jitter.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _angle.Write(bw);
        _unnamed15.Write(bw);
        _unnamed16.Write(bw);
        _duration5.Write(bw);
        _falloffFunction.Write(bw);
        _unnamed17.Write(bw);
        _randomTranslation.Write(bw);
        _randomRotation.Write(bw);
        _unnamed18.Write(bw);
        _wobbleFunction.Write(bw);
        _unnamed19.Write(bw);
        _wobbleFunctionPeriod.Write(bw);
        _wobbleWeight.Write(bw);
        _unnamed20.Write(bw);
        _unnamed21.Write(bw);
        _unnamed22.Write(bw);
        _sound.Write(bw);
        _unnamed23.Write(bw);
        _forwardVelocity.Write(bw);
        _forwardRadius.Write(bw);
        _forwardExponent.Write(bw);
        _unnamed24.Write(bw);
        _outwardVelocity.Write(bw);
        _outwardRadius.Write(bw);
        _outwardExponent.Write(bw);
        _unnamed25.Write(bw);
        _sideEffect.Write(bw);
        _category.Write(bw);
        _flags2.Write(bw);
        _aOECoreRadius.Write(bw);
        _damageLowerBound.Write(bw);
        _damageUpperBound.Write(bw);
        _vehiclePassthroughPenalty.Write(bw);
        _activeCamouflageDamage.Write(bw);
        _stun.Write(bw);
        _maximumStun.Write(bw);
        _stunTime.Write(bw);
        _unnamed26.Write(bw);
        _instantaneousAcceleration.Write(bw);
        _unnamed27.Write(bw);
        _unnamed28.Write(bw);
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
        _unnamed29.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sound.WriteString(writer);
      }
    }
  }
}
