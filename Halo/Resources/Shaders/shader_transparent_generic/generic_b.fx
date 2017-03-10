// this file is part of a shader_tranaparent_generic shader generation method.
// written by SwampFox

	return saturate(scratch_0);
}

technique GenericTransparent
{
	pass generic
	{
		ZEnable = true;
		VertexShader = compile vs_1_1 genericVS_1_1();
		PixelShader = compile ps_2_0 ps_transparent_generic();
	}
}
