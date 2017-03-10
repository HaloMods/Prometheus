using Interfaces.Games;
using Games.Halo2.Tags.Classes;

namespace Games.Halo2.Tags
{
	/// <summary>
	/// Implements the ITypeTable interface with respect to Halo 2.
	/// </summary>
	public class Halo2TypeTable : TypeTable
	{
		public Halo2TypeTable()
		{
			AddEntry("hlmt", "model", typeof(model));
			AddEntry("mode", "render_model", typeof(render_model));
			AddEntry("coll", "collision_model", typeof(collision_model));
			AddEntry("phmo", "physics_model", typeof(physics_model));
			AddEntry("bitm", "bitmap", typeof(bitmap));
			AddEntry("colo", "color_table", typeof(color_table));
			AddEntry("unic", "multilingual_unicode_string_list", typeof(multilingual_unicode_string_list));
			AddEntry("unit", "unit", typeof(unit));
			AddEntry("bipd", "biped", typeof(biped));
			AddEntry("vehi", "vehicle", typeof(vehicle));
			AddEntry("scen", "scenery", typeof(scenery));
			AddEntry("bloc", "crate", typeof(crate));
			AddEntry("crea", "creature", typeof(creature));
			AddEntry("phys", "physics", typeof(physics));
			AddEntry("obje", "object", typeof(Games.Halo2.Tags.Classes.@object));
			AddEntry("cont", "contrail", typeof(contrail));
			AddEntry("weap", "weapon", typeof(weapon));
			AddEntry("ligh", "light", typeof(light));
			AddEntry("effe", "effect", typeof(effect));
			AddEntry("prt3", "particle", typeof(particle));
			AddEntry("PRTM", "particle_model", typeof(particle_model));
			AddEntry("pmov", "particle_physics", typeof(particle_physics));
			AddEntry("matg", "globals", typeof(globals));
			AddEntry("snd!", "sound", typeof(sound));
			AddEntry("lsnd", "sound_looping", typeof(sound_looping));
			AddEntry("item", "item", typeof(item));
			AddEntry("eqip", "equipment", typeof(equipment));
			AddEntry("ant!", "antenna", typeof(antenna));
			AddEntry("MGS2", "light_volume", typeof(light_volume));
			AddEntry("tdtl", "liquid", typeof(liquid));
			AddEntry("devo", "cellular_automata", typeof(cellular_automata));
			AddEntry("whip", "cellular_automata2d", typeof(cellular_automata2d));
			AddEntry("BooM", "stereo_system", typeof(stereo_system));
			AddEntry("trak", "camera_track", typeof(camera_track));
			AddEntry("proj", "projectile", typeof(projectile));
			AddEntry("devi", "device", typeof(device));
			AddEntry("mach", "device_machine", typeof(device_machine));
			AddEntry("ctrl", "device_control", typeof(device_control));
			AddEntry("lifi", "device_light_fixture", typeof(device_light_fixture));
			AddEntry("pphy", "point_physics", typeof(point_physics));
			AddEntry("ltmp", "scenario_structure_lightmap", typeof(scenario_structure_lightmap));
			AddEntry("sbsp", "scenario_structure_bsp", typeof(scenario_structure_bsp));
			AddEntry("scnr", "scenario", typeof(scenario));
			AddEntry("shad", "shader", typeof(shader));
			AddEntry("stem", "shader_template", typeof(shader_template));
			AddEntry("slit", "shader_light_response", typeof(shader_light_response));
			AddEntry("spas", "shader_pass", typeof(shader_pass));
			AddEntry("vrtx", "vertex_shader", typeof(vertex_shader));
			AddEntry("pixl", "pixel_shader", typeof(pixel_shader));
			AddEntry("DECR", "decorator_set", typeof(decorator_set));
			AddEntry("DECP", "decorators", typeof(decorators));
			AddEntry("sky ", "sky", typeof(sky));
			AddEntry("wind", "wind", typeof(wind));
			AddEntry("snde", "sound_environment", typeof(sound_environment));
			AddEntry("lens", "lens_flare", typeof(lens_flare));
			AddEntry("fog ", "planar_fog", typeof(planar_fog));
			AddEntry("fpch", "patchy_fog", typeof(patchy_fog));
			AddEntry("metr", "meter", typeof(meter));
			AddEntry("deca", "decal", typeof(decal));
			AddEntry("coln", "colony", typeof(colony));
			AddEntry("jpt!", "damage_effect", typeof(damage_effect));
			AddEntry("udlg", "dialogue", typeof(dialogue));
			AddEntry("itmc", "item_collection", typeof(item_collection));
			AddEntry("vehc", "vehicle_collection", typeof(vehicle_collection));
			//AddEntry("wphi", "weapon_hud_interface", typeof(weapon_hud_interface));
			//AddEntry("grhi", "grenade_hud_interface", typeof(grenade_hud_interface));
			//AddEntry("unhi", "unit_hud_interface", typeof(unit_hud_interface));
			AddEntry("nhdt", "new_hud_definition", typeof(new_hud_definition));
			AddEntry("hud#", "hud_number", typeof(hud_number));
			AddEntry("hudg", "hud_globals", typeof(hud_globals));
			AddEntry("mply", "multiplayer_scenario_description", typeof(multiplayer_scenario_description));
			AddEntry("dobc", "detail_object_collection", typeof(detail_object_collection));
			AddEntry("ssce", "sound_scenery", typeof(sound_scenery));
			AddEntry("hmt ", "hud_message_text", typeof(hud_message_text));
			AddEntry("wgit", "user_interface_screen_widget_definition", typeof(user_interface_screen_widget_definition));
			AddEntry("skin", "user_interface_list_skin_definition", typeof(user_interface_list_skin_definition));
			AddEntry("wgtz", "user_interface_globals_definition", typeof(user_interface_globals_definition));
			AddEntry("wigl", "user_interface_shared_globals_definition", typeof(user_interface_shared_globals_definition));
			AddEntry("sily", "text_value_pair_definition", typeof(text_value_pair_definition));
			AddEntry("goof", "multiplayer_variant_settings_interface_definition", typeof(multiplayer_variant_settings_interface_definition));
			AddEntry("foot", "material_effects", typeof(material_effects));
			AddEntry("garb", "garbage", typeof(garbage));
			AddEntry("styl", "style", typeof(style));
			AddEntry("char", "character", typeof(character));
			AddEntry("adlg", "ai_dialogue_globals", typeof(ai_dialogue_globals));
			AddEntry("mdlg", "ai_mission_dialogue", typeof(ai_mission_dialogue));
			//AddEntry("*cen", "scenario_scenery_resource", typeof(scenario_scenery_resource));
			//AddEntry("*ipd", "scenario_bipeds_resource", typeof(scenario_bipeds_resource));
			//AddEntry("*ehi", "scenario_vehicles_resource", typeof(scenario_vehicles_resource));
			//AddEntry("*qip", "scenario_equipment_resource", typeof(scenario_equipment_resource));
			//AddEntry("*eap", "scenario_weapons_resource", typeof(scenario_weapons_resource));
			//AddEntry("*sce", "scenario_sound_scenery_resource", typeof(scenario_sound_scenery_resource));
			//AddEntry("*igh", "scenario_lights_resource", typeof(scenario_lights_resource));
			//AddEntry("dgr*", "scenario_devices_resource", typeof(scenario_devices_resource));
			//AddEntry("dec*", "scenario_decals_resource", typeof(scenario_decals_resource));
			//AddEntry("cin*", "scenario_cinematics_resource", typeof(scenario_cinematics_resource));
			//AddEntry("trg*", "scenario_trigger_volumes_resource", typeof(scenario_trigger_volumes_resource));
			//AddEntry("clu*", "scenario_cluster_data_resource", typeof(scenario_cluster_data_resource));
			//AddEntry("*rea", "scenario_creature_resource", typeof(scenario_creature_resource));
			//AddEntry("dc*s", "scenario_decorators_resource", typeof(scenario_decorators_resource));
			//AddEntry("sslt", "scenario_structure_lighting_resource", typeof(scenario_structure_lighting_resource));
			//AddEntry("hsc*", "scenario_hs_source_file", typeof(scenario_hs_source_file));
			//AddEntry("ai**", "scenario_ai_resource", typeof(scenario_ai_resource));
			//AddEntry("/**/", "scenario_comments_resource", typeof(scenario_comments_resource));
			AddEntry("bsdt", "breakable_surface", typeof(breakable_surface));
			AddEntry("mpdt", "material_physics", typeof(material_physics));
			AddEntry("sncl", "sound_classes", typeof(sound_classes));
			AddEntry("mulg", "multiplayer_globals", typeof(multiplayer_globals));
			AddEntry("<fx>", "sound_effect_template", typeof(sound_effect_template));
			AddEntry("sfx+", "sound_effect_collection", typeof(sound_effect_collection));
			AddEntry("gldf", "chocolate_mountain", typeof(chocolate_mountain));
			AddEntry("jmad", "model_animation_graph", typeof(model_animation_graph));
			AddEntry("clwd", "cloth", typeof(cloth));
			AddEntry("egor", "screen_effect", typeof(screen_effect));
			AddEntry("weat", "weather_system", typeof(weather_system));
			AddEntry("snmx", "sound_mix", typeof(sound_mix));
			AddEntry("spk!", "sound_dialogue_constants", typeof(sound_dialogue_constants));
			AddEntry("ugh!", "sound_cache_file_gestalt", typeof(sound_cache_file_gestalt));
			//AddEntry("$#!+", "cache_file_sound", typeof(cache_file_sound));
      //AddEntry("mcsr", "mouse_cursor_definition", typeof(mouse_cursor_definition));
		}
	}
}