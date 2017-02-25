// Compiled shader for PC, Mac & Linux Standalone, uncompressed size: 0.7KB

// Skipping shader variants that would not be included into build of current scene.

Shader "houseMask" {
SubShader { 
 Tags { "QUEUE"="Geometry-1" "RenderType"="Opaque" }
 Pass {
  Tags { "QUEUE"="Geometry-1" "RenderType"="Opaque" }
  ZTest Less
  ZWrite Off
  Stencil {
   Ref 1
   Pass Replace
  }
  ColorMask 0
  GpuProgramID 54303
Program "vp" {
// Platform opengl had shader errors
//   <no keywords>
// Platform metal had shader errors
//   <no keywords>
// Platform glcore had shader errors
//   <no keywords>
}
Program "fp" {
// Platform opengl skipped due to earlier errors
// Platform metal skipped due to earlier errors
// Platform glcore skipped due to earlier errors
// Platform opengl skipped due to earlier errors
// Platform metal had shader errors
//   <no keywords>
// Platform glcore skipped due to earlier errors
}
 }
}
}