   M S B A M L   `   `   `  ���� G  CBatch Rename, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Batch_RenameBatch_Rename      Batch_Rename.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ,localclr-namespace:Batch_Rename     -     �Name$  
mainWindow�� � Title$ 	My Rename��$	��600��$
��1050�� � WindowStartupLocation$ CenterScreen=� � WindowState$ Normal=� � ShowInTaskbar .  � 
ResizeMode$ 	CanResize=�.��]� .+�`� $	��Top=�.�c� .@��� -   $��bnt_Refresh��.����  �� Orientation$ 
Horizontal=�.+��� -   $��IconRefresh��$��/Icon/refresh-16.png���� $��Refresh��$��6,0,0,0q��� o� .@�m� -   $��MenuHelp��$��_Help�� m� Icon �� -   $��IconHelp��$��Icon/help-16.png��.@��� m� $��_About���� �� -   $��
StartBatch��.���� $ 
Horizontal=�.+��� -   $��	IconBatch��$��/Icon/play-16.png���� $��Start Batch��$��5,0,0,0q��� $ Vertical=�$
��Left=�.+�`� .�c� .@�o� .@�m� -   $��MenuAddMethod��$��_Add Method�� �� -	   $��IconAddMethod��$��/Icon/add-16.png��.@�m� -
   $��NewName��$��	_New Name��m� -   $��NewCase��$��	_New Case��m� -   $
��Move��$��_Move��m� -   $��Remove��$��_Remove��m� -   $��Replace��$��_Replace��m� -   $
��Trim��$��_Trim��m� -   $��	Extension��$��
_Extension���� �� -   $��IconLeftClear��.���� $��/Icon/x-mark-16.png���� -   $��	bnt_Clear��.���� $ 
Horizontal=�.+��� -   $��IconRightClear��$��/Icon/delete-16.png���� $��Clear��$��5,0,0,0q��� �� -    ��Name$ 	bnt_First��.���� -   $��	IconFirst��$��/Icon/first.png���� -   $ bnt_Top��.���� -   $��IconTop��$��/Icon/top.png���� -   $ bnt_Down��.���� -   $��IconDown��$��/Icon/down.png���� -   $ bnt_Last��.���� -   $��IconLast��$��/Icon/last.png��`� .�c� .@��� -   $��bnt_AddPreset��.���� -   $��IconAddPreset��$��/Icon/add-folder-16.png���� -   $ bnt_SavePreset��.���� -   $��IconSavePreset��$��/Icon/save-16.png���� �� $��Preset: ���� -    $��ComboboxPreset��$	��150��.@��� �� -!   	 ��Name$	 ListViewMethod��$	��473��$��2q�
 �� SelectionMode$
 Single=�����  �� 
TargetType" ��.���  �� Property � �� �� Value �� .R�9�  9�Name$ ExpanderMethod������ " 9�.���  � ��
 ����� �� Triggers P�  P� Property �@9�
IsExpanded P� Value . . ���  � ��
 ��ح���  �� Binding �� *IsCheckMethod+ �� Value	 False.a���  � ��
 ���������  ��Name$ BorderMethod��$��2q�
�������._��  � ColumnDefinitions �� $	��250 ��� $��30 ��� $��30 �.+�� $��0��.+��� $��Center=�$��24(����� *
NameMethod+� $��1��.+���  d� 	IsChecked �� *IsCheckMethod+ � LayoutTransform ��  �� ScaleX$ 2Q� �� ScaleY$ 2Q�� $��2��.+��� $ RemoveMethod��-"   .���� $��Icon\x-mark-5-24.png��$
��Fill=�.���� $	��200������ " ��.���  � ��$ 5q���  � ��
 ����� ��  �� *IsCheckMethod+ True.a���  � ��
 ��ح�._� � ���� *
PageMethod+ �� Mode$ TwoWay=��� $ Vertical=�$��Right=�.+���  �� TabStripPlacement$	 Top=�.@��� $��Rename Files�� �� 
IsSelected . .���� $ Vertical=�.+�`� .�c� .@�o� .@�m� -#   $��MenuAddFile��$
��_Add�� �� -$    ��Name$ IconAddFile��$��/Icon/report-3-16.png��.@�m� -%   $��Files��$��_Files..�� �� -&   $��IconFile��$��/Icon/file-16.png��m� -'   $��Directories��$��_Directoties..�� �� -(   $��IconDirectories��$��/Icon/full-folder-16.png���� �� -)   $ bnt_FirstFile��.���� -*   $��IconFirstFile��$��/Icon/first.png���� -+   $ 
bnt_UpFile��.���� -,   $��IconTopFile��$��/Icon/top.png���� --   $ bnt_DownFile��.���� -.   $��IconDownFile��$��/Icon/down.png���� -/   $ bnt_LastFile��.���� -0   $��IconLastFile��$��/Icon/last.png���� -1   $	 ListFileSelected��$
 Single=�$	��480��$��Visible=�
�������$
��Bold"� �� View �� .P��� ���� -2    �� CellTemplate �� .R��� $��7q� �� *
IsGroovy+�� $��Filename��  �� Width$	  180��! �� DisplayMemberBinding! �� *
Filename+�� $��New Filename��$	  180��! �� *	Newname+�� $��	Extension��$  60��! �� *	Extension+�� $
��Path��$	  180��! �� *Path+�� $��Error��$	  180��! �� *Error+�� $��Rename Folders��.���� $ Vertical=����	#FFF6F6F6.+�`� .�c� .@�o� .@�m� -3   $��MenuAddFolder��$
��_Add�� �� -4   $��IconMenuAddFolder��$��/Icon/folder-16.png��.@�m� -5   $��Directories1��$��_Directoties..�� �� -6   $��IconDirectories1��$��/Icon/full-folder-16.png��m� -7   $��SubDirectories��$��_SubDirectoties..�� �� -8   $��IconSubDirectories��$��/Icon/full-folder-16.png���� �� -9   $ bnt_FirstFolder��.���� -:   $��IconFirstFolder��$��/Icon/first.png���� -;   $ bnt_UpFolder��.���� -<   $��IconTopFolder��$��/Icon/top.png���� -=   $ bnt_DownFolder��.���� ->   $��IconDownFolder��$��/Icon/down.png���� -?   $ bnt_LastFolder��.���� -@   $��IconLastFolder��$��/Icon/last.png���� -A   $	 ListFolderSelected��$
 Single=�$	��480��$��Visible=�
����ح�$
��Bold"� �� .P��� ���� -B    �� .R��� $��7q�
" � Tag" �� *IsGroovyDir+ �� *IsGroovyDir+�� $��
Foldername��$	  180��! �� *
Foldername+�� $��New Foldername��$	  180��! �� *NewFoldername+�� $
��Path��$	  180��! �� *
PathFolder+�� $��Error��$	  180��! �� *ErrorFolder+