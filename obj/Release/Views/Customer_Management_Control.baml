   M S B A M L   `   `   `  ���� E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  =#clr-namespace:Car_Rental.ConvertersCar_Rental.Converters  =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels  2    ,Car_Rental.Views.Customer_Management_Control   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  *localclr-namespace:Car_Rental.Views  .conv#clr-namespace:Car_Rental.Converters  ,vm#clr-namespace:Car_Rental.ViewModels  $	��750��$	��300��  � DataContext  7  1Car_Rental.ViewModels.CustomerManagementViewModel   � 	Resources 6   0Car_Rental.Converters.EmptyToVisibilityConverter   EmptyToVisibilityConverter-   'Car_Rental.Converters.FuelTypeConverter  FuelTypeConverter,   &Car_Rental.Converters.GearboxConverter  GearboxConverter.   (Car_Rental.Converters.StatusCarConverter  StatusCarConverter��%<   &	        &	      &	 
     &	              .���  � RowDefinitions �� $��50 ��� .+�� $��0��.+���  �� Orientation$ 
Horizontal=�$��Center=�$
��Left=�$��0��.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�$��30��$��30��  plainTextColor3   
Foreground# [ �� -    ��Name$ SearchTextBox��
�������$��13(�$��24��$	��250��
������ $��Medium"�$��
Montserrat)� �� 
CaretBrush# [ #��[ $��0,0,0,1q�$��Center=�$��5,5,0,0q����� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=��� -   $	��Add��$	��100��$��30��$��15,0,0,0q����� 
 �� 
TargetType"
 ��.���  �� Property � �� �� Value �#773DFF��  � �� ��  �� 
TargetType" ��.R��� $��30��$	��100�� �� CornerRadius$ 15��#��z��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �#836EFB�� -   $
��Edit��$	��100��$��30��$��15,0,0,0q����� "
 ��.���  � �� �#773DFF��  � �� �� " ��.R��� $��30��$	��100��$ 15��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#836EFB�� -   $��Remove��$	��100��$��30��$��15,0,0,0q����� "
 ��.���  � �� �#773DFF��  � �� �� " ��.R��� $��30��$	��100��$ 15��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#836EFB�� $��1�����#200F53$ 10�� �� Padding$ 10q�._�� .+�&   System.Windows.Controls.DataGrid  -     Name$ CustomerDataGrid��   ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$ *	 ���#200F53   
IsReadOnly .    SelectionMode$ Single=�   AutoGenerateColumns .     RowBackground �#36257E   AlternatingRowBackground �#2B1A69   HeadersVisibility$ Column=�   GridLinesVisibility$
 None=�$��0q�$��Stretch=�$��Stretch=����� *	Customers+   ColumnHeaderStyle �� =
  7System.Windows.Controls.Primitives.DataGridColumnHeader"
 
 .���  � ��
 ���� ��  � ��
 �������  � ��$ 0,0,0,0q���  � ��$ 
Montserrat)���  � ��$ 18(�   	CellStyle �� *  $System.Windows.Controls.DataGridCell"
  .���  � ��$ 16(���  � ��
 �����   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��    Width$
  Auto	 !   MinWidth$! 70Q�1  +System.Windows.Controls.DataGridBoundColumn"   Binding" �� *	FirstName+  $ Surname��$
  Auto	 $! 90Q�" �� *
LastName+  $ Email��$
  Auto	 $	! 100Q�" �� *Email+  $ Phone��$
  Auto	 $	! 100Q�" �� *Phone+  $ Pesel��$
  Auto	 $	! 100Q�" �� *PESEL+  $ License number��$
  Auto	 $	! 140Q�" �� *DriverLicenseNumber+  $ Date of birth��$
  Auto	 $	! 120Q�" �� *DateOfBirth+  $ Street��$
  Auto	 $! 80Q�" �� *Street+  $
 City��$
  Auto	 $! 60Q�" �� *City+  $ Postal code��$
  Auto	 $! 60Q�" �� *
PostalCode+�� $��Brak wyników��
�������$��30(�$��
Montserrat)�$��Center=�$��Center=�y��� *Customers.Count+# �� 	Converter## [  