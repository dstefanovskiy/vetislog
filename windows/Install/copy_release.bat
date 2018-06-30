xcopy D:\Projects\vetislog\windows\VetisLog\bin\Release /Y D:\Projects\vetislog\windows\Bin
xcopy D:\Projects\vetislog\windows\VetisLog\bin\Release\*.* /Y D:\Projects\vetislog\windows\Bin\
xcopy D:\Projects\vetislog\windows\VetisLog.Agent\bin\Release /Y D:\Projects\vetislog\windows\Bin
xcopy D:\Projects\vetislog\windows\VetisLog.Agent\bin\Release\*.* /Y D:\Projects\vetislog\windows\Bin\
xcopy D:\Projects\vetislog\windows\VetisLog.Checker\bin\Release\*.* /Y D:\Projects\vetislog\windows\Bin\
del /F /Q D:\Projects\vetislog\windows\Bin\*.pdb
del /F /Q D:\Projects\vetislog\windows\Bin\*.xml