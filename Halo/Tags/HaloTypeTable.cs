using Games.Halo.Tags.Classes;
using Interfaces.Games;

namespace Games.Halo.Tags
{
  /// <summary>
  /// Implements the ITypeTable interface with respect to Halo.
  /// </summary>
  public class HaloTypeTable : TypeTable
  {
    public HaloTypeTable()
    {
      AddEntry("actr", "actor", typeof(actor));
      AddEntry("actv", "actor_variant", typeof(actor_variant));
      AddEntry("ant!", "antenna", typeof(antenna));
      AddEntry("bipd", "biped", typeof(biped), "Bipeds");
      AddEntry("bitm", "bitmap", typeof(bitmap));
      AddEntry("trak", "camera_track", typeof(camera_track));
      AddEntry("colo", "color_table", typeof(color_table));
      AddEntry("cdmg", "continuous_damage_effect", typeof(continuous_damage_effect));
      AddEntry("cont", "contrail", typeof(contrail));
      AddEntry("jpt!", "damage_effect", typeof(damage_effect));
      AddEntry("deca", "decal", typeof(decal));
      AddEntry("dobc", "detail_object_collection", typeof(detail_object_collection));
      AddEntry("devi", "device", typeof(device), "Devices");
      AddEntry("ctrl", "device_control", typeof(device_control));
      AddEntry("lifi", "device_light_fixture", typeof(device_light_fixture));
      AddEntry("mach", "device_machine", typeof(device_machine), "Misc");
      AddEntry("udlg", "dialogue", typeof(dialogue));
      AddEntry("effe", "effect", typeof(effect));
      AddEntry("eqip", "equipment", typeof(equipment), "Misc");
      AddEntry("flag", "flag", typeof(flag));
      AddEntry("fog ", "fog", typeof(fog));
      AddEntry("font", "font", typeof(font));
      AddEntry("garb", "garbage", typeof(garbage));
      AddEntry("mod2", "gbxmodel", typeof(gbxmodel));
      AddEntry("matg", "globals", typeof(globals), "Globals");
      AddEntry("glw!", "glow", typeof(glow));
      AddEntry("grhi", "grenade_hud_interface", typeof(grenade_hud_interface));
      AddEntry("hudg", "hud_globals", typeof(hud_globals));
      AddEntry("hmt ", "hud_message_text", typeof(hud_message_text));
      AddEntry("hud#", "hud_number", typeof(hud_number));
      AddEntry("devc", "input_device_defaults", typeof(input_device_defaults));
      AddEntry("item", "item", typeof(item));
      AddEntry("itmc", "item_collection", typeof(item_collection), "Item Collections");
      AddEntry("lens", "lens_flare", typeof(lens_flare));
      AddEntry("ligh", "light", typeof(light));
      AddEntry("mgs2", "light_volume", typeof(light_volume));
      AddEntry("elec", "lightning", typeof(lightning));
      AddEntry("foot", "material_effects", typeof(material_effects));
      AddEntry("metr", "meter", typeof(meter));
      AddEntry("mode", "model", typeof(model));
      AddEntry("antr", "model_animations", typeof(model_animations));
      AddEntry("coll", "model_collision_geometry", typeof(model_collision_geometry));
      AddEntry("mply", "multiplayer_scenario_description", typeof(multiplayer_scenario_description));
      AddEntry("obje", "object", typeof(@object));
      AddEntry("part", "particle", typeof(particle));
      AddEntry("pctl", "particle_system", typeof(particle_system));
      AddEntry("phys", "physics", typeof(physics));
      AddEntry("plac", "placeholder", typeof(placeholder));
      AddEntry("pphy", "point_physics", typeof(point_physics));
      AddEntry("ngpr", "preferences_network_game", typeof(preferences_network_game));
      AddEntry("proj", "projectile", typeof(projectile));
      AddEntry("scnr", "scenario", typeof(scenario), "Scenarios");
      AddEntry("sbsp", "scenario_structure_bsp", typeof(scenario_structure_bsp), "BSP");
      AddEntry("scen", "scenery", typeof(scenery), "Scenery");
      AddEntry("shdr", "shader", typeof(shader));
      AddEntry("senv", "shader_environment", typeof(shader_environment));
      AddEntry("soso", "shader_model", typeof(shader_model));
      AddEntry("schi", "shader_transparent_chicago", typeof(shader_transparent_chicago));
      AddEntry("scex", "shader_transparent_chicago_extended", typeof(shader_transparent_chicago_extended));
      AddEntry("sotr", "shader_transparent_generic", typeof(shader_transparent_generic));
      AddEntry("sgla", "shader_transparent_glass", typeof(shader_transparent_glass));
      AddEntry("smet", "shader_transparent_meter", typeof(shader_transparent_meter));
      AddEntry("spla", "shader_transparent_plasma", typeof(shader_transparent_plasma));
      AddEntry("swat", "shader_transparent_water", typeof(shader_transparent_water));
      AddEntry("sky ", "sky", typeof(sky));
      AddEntry("snd!", "sound", typeof(sound));
      AddEntry("snde", "sound_environment", typeof(sound_environment));
      AddEntry("lsnd", "sound_looping", typeof(sound_looping));
      AddEntry("ssce", "sound_scenery", typeof(sound_scenery));
      AddEntry("boom", "spheroid", typeof(spheroid));
      AddEntry("str#", "string_list", typeof(string_list));
      AddEntry("tagc", "tag_collection", typeof(tag_collection));
#if DEBUG
      AddEntry("test", "testing", typeof(testing));
#endif
      AddEntry("Soul", "ui_widget_collection", typeof(ui_widget_collection));
      AddEntry("DeLa", "ui_widget_definition", typeof(ui_widget_definition));
      AddEntry("ustr", "unicode_string_list", typeof(unicode_string_list));
      AddEntry("unit", "unit", typeof(unit));
      AddEntry("unhi", "unit_hud_interface", typeof(unit_hud_interface));
      AddEntry("vehi", "vehicle", typeof(vehicle), "Vehicles");
      AddEntry("vcky", "virtual_keyboard", typeof(virtual_keyboard));
      AddEntry("weap", "weapon", typeof(weapon), "Weapons");
      AddEntry("wphi", "weapon_hud_interface", typeof(weapon_hud_interface));
      AddEntry("rain", "weather_particle_system", typeof(weather_particle_system));
      AddEntry("wind", "wind", typeof (wind));
    }
  }
}
