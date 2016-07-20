
!include "MUI2.nsh"
!define PRODUCT_NAME "SQLiteManager"
!define PRODUCT_VERSION "0.1.4"

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "${PRODUCT_NAME}_${PRODUCT_VERSION}_Setup.exe"

InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"

InstallDirRegKey HKCU "Software\${PRODUCT_NAME}" ""

RequestExecutionLevel user

!define MUI_ABORTWARNING

!insertmacro MUI_PAGE_LICENSE "..\lgpl-3.0.txt"
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"

Section "${PRODUCT_NAME}" Section01

	SetOutPath "$INSTDIR\bin"  
	File "..\dist\sqlitemanager.exe"
	File "..\dist\ICSharpCode.TextEditor.dll"
	File "..\dist\SQLiteManager.Core.dll"
	File "..\dist\System.Data.SQLite.dll"
	
	SetOutPath "$INSTDIR\bin"
	
	CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}"
	CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk" "$INSTDIR\bin\sqlitemanager.exe"
	CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\bin\sqlitemanager.exe"

	SetOutPath "$INSTDIR"
	File "..\changelogs.txt"
	File "..\lgpl-3.0.txt"
	File "..\readme.txt"
	
	WriteRegStr HKCU "Software\${PRODUCT_NAME}" "" $INSTDIR
	
	WriteUninstaller "$INSTDIR\Uninstall.exe"
	SetOutPath "$INSTDIR\bin"
	CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall.lnk" "$INSTDIR\Uninstall.exe"

SectionEnd

!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
	!insertmacro MUI_DESCRIPTION_TEXT ${Section01} "SQLite Manager"
!insertmacro MUI_FUNCTION_DESCRIPTION_END

Section "Uninstall"

	Delete "$INSTDIR\Uninstall.exe"
	
	Delete "$INSTDIR\bin\sqlitemanager.exe"
	Delete "$INSTDIR\bin\ICSharpCode.TextEditor.dll"
	Delete "$INSTDIR\bin\SQLiteManager.Core.dll"
	Delete "$INSTDIR\bin\System.Data.SQLite.dll"
	RMDir "$INSTDIR\bin"
	
	Delete "$INSTDIR\changelogs.txt"
	Delete "$INSTDIR\lgpl-3.0.txt"
	Delete "$INSTDIR\readme.txt"
	
	RMDir "$INSTDIR"

	Delete "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk"
	Delete "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall.lnk"
	RMDir "$SMPROGRAMS\${PRODUCT_NAME}"
	Delete "$DESKTOP\${PRODUCT_NAME}.lnk"

	DeleteRegKey /ifempty HKCU "Software\${PRODUCT_NAME}"

SectionEnd