   M S B A M L   `   `   `  ���� E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  =#clr-namespace:Car_Rental.ConvertersCar_Rental.Converters  =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels  (    "Car_Rental.Views.Show_Cars_Control   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  *localclr-namespace:Car_Rental.Views  .conv#clr-namespace:Car_Rental.Converters  ,vm#clr-namespace:Car_Rental.ViewModels  -   $	��750��$	��300��  � DataContext  -   'Car_Rental.ViewModels.ShowCarsViewModel   � 	Resources 6   0Car_Rental.Converters.EmptyToVisibilityConverter   EmptyToVisibilityConverter-   'Car_Rental.Converters.FuelTypeConverter  FuelTypeConverter,   &Car_Rental.Converters.GearboxConverter  GearboxConverter.   (Car_Rental.Converters.StatusCarConverter  StatusCarConverter��%<   &	        &	      &	 
     &	              .���  � RowDefinitions �� $��50 ��� .+�� $��0��.+���  �� Orientation$ 
Horizontal=�$��Center=�$
��Left=�$��0��.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�$��30��$��30��  plainTextColor3   
Foreground# [ �� -    ��Name$ SearchTextBox��
�������$��13(�$��24��$	��150��
������ $��Medium"�$��
Montserrat)� �� 
CaretBrush# [ #��[ $��0,0,0,1q�$��Center=�$��5,5,0,0q����� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=��� -   $
��Rent��$	��100��$��30��$��15,0,0,0q����� 
 �� 
TargetType"
 ��.���  �� Property � �� �� Value �#773DFF��  � �� ��  �� 
TargetType" ��.R��� $��30��$	��100�� �� CornerRadius$ 15��#��z��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �#836EFB�� -   $��Return��$	��100��$��30��$��15,0,0,0q����� "
 ��.���  � �� �#773DFF��  � �� �� " ��.R��� $��30��$	��100��$ 15��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#836EFB�� -    ��Name$ FiltersButton��$��Filters��$	��100��$��30��$��15,0,0,0q����� "
 ��.���  � �� �#773DFF��  � �� �� " ��.R��� $��30��$	��100��$ 15��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#836EFB� -    �Name$ FiltersPopup��$��Bottom=� � AllowsTransparency .  � 	StaysOpen .  � PlacementTarget ��  �� ElementName$ FiltersButton��.���� 
�������
�������$��1q� �� Padding$ 10q�._��� $ Vertical=�.+��� $��	Available��$��0,0,0,5q� d� 	IsChecked �� *IsAvailableChecked+$	 TwoWay=��� $��Reserved��$��0,0,0,5q� �� *IsReservedChecked+$	 TwoWay=��� $��Rented��$��0,0,0,5q� �� *IsRentedChecked+$	 TwoWay=��� $��Maintenance��$��0,0,0,5q� �� *IsMaintenanceChecked+$	 TwoWay=��� $��
In service��$��0,0,0,5q� �� *IsInServiceChecked+$	 TwoWay=��� $��1�����#200F53$ 10��$ 10q�._�� .+�&   System.Windows.Controls.DataGrid  -     Name$ CarDataGrid��   ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$ *	 ���#200F53   
IsReadOnly .    SelectionMode$ Single=�   AutoGenerateColumns .     RowBackground �#36257E    AlternatingRowBackground  �#2B1A69!   HeadersVisibility$! Column=�"   GridLinesVisibility$
" None=�$��0q�$��Stretch=�$��Stretch=����� *FilteredCars+#   ColumnHeaderStyle# �� =
  7System.Windows.Controls.Primitives.DataGridColumnHeader"
 
 .���  � ��
 ���� ��  � ��
 �������  � ��$ 0,0,0,0q���  � ��$ 
Montserrat)���  � ��$ 18(���  � ��$ SemiBold"�$   	CellStyle$ �� *  $System.Windows.Controls.DataGridCell"
  .���  � ��
 �������  � ��$ 16(���  � ��$ Center=�%   Columns% 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn&   Header$& Image��'   Width$	' 160	 (   CellTemplate( �� .R��� $	��150��$	��100��$��UniformToFill=�$
��Left=�$��Center=����� *	ImagePath+0  *System.Windows.Controls.DataGridTextColumn  $& Class��$
' Auto	 )   MinWidth$) 50Q�1  +System.Windows.Controls.DataGridBoundColumn*   Binding* �� *VehicleClass+  $& Brand��$
' Auto	 $	) 100Q�* �� *Brand+  $& Model��$
' Auto	 $) 70Q�* �� *Model+  $
& Year��$
' Auto	 $) 50Q�* �� *ProductionYear+  $& LicensePlate��$
' Auto	 $	) 110Q�* �� *LicensePlate+  $& 	Fuel Type��$
' Auto	 $) 90Q�* �� *
FuelType++ �� 	Converter#+ [   $& Gearbox��$
' Auto	 $	) 100Q�* �� *	Gearbox+#+ [   $& Color��$
' Auto	 $) 90Q�* �� *Color+  $& Mileage��$
' Auto	 $) 80Q�* �� *	Mileage+  $& Status��$
' Auto	 $) 60Q�* �� *	StatusCar+#+ [ �� $��Brak wyników��
�������$��30(�$��
Montserrat)�$��Center=�$��Center=�y��� *FilteredCars.Count+#+ [  