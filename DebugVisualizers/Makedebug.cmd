@ECHO OFF
call vsvars3220.bat
pushd DebugVisualizers
msbuild DebugVisualizersDebug.csproj /t:rebuild /p:Configuration=Debug
popd