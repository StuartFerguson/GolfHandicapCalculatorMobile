$outputFolder=$args[0]

& 'D:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\bin\MSBuild.exe' /t:Clean /p:Configuration=Release

& 'D:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\bin\MSBuild.exe' /t:PackageForAndroid /p:Configuration=Release

& 'c:\Program Files (x86)\Android\android-sdk\build-tools\26.0.2\zipalign.exe' -f -v 4 bin\Release\com.golfhandicapping.mobile.apk bin\Release\com.golfhandicapping.mobile-signed.apk

& 'c:\Program Files (x86)\Android\android-sdk\build-tools\26.0.2\apksigner.bat' sign --ks golfmobile --ks-pass pass:Sc0tland bin\Release\com.golfhandicapping.mobile-signed.apk

Copy-Item .\bin\Release\com.golfhandicapping.mobile-signed.apk -Destination D:\AndroidReleases\$outputFolder

