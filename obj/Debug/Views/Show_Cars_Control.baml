   M S B A M L   `   `   `  ����E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  5      =#clr-namespace:Car_Rental.ConvertersCar_Rental.Converters  5      =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels  5	      (    "Car_Rental.Views.Show_Cars_Control   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      *localclr-namespace:Car_Rental.Views  5      .conv#clr-namespace:Car_Rental.Converters  5      ,vm#clr-namespace:Car_Rental.ViewModels  5	      -   5        $	��750��5      $	��300��5        � DataContext  5      -   'Car_Rental.ViewModels.ShowCarsViewModel  5   
    � 	Resources 5      6   0Car_Rental.Converters.EmptyToVisibilityConverter   EmptyToVisibilityConverter-   'Car_Rental.Converters.FuelTypeConverter  FuelTypeConverter,   &Car_Rental.Converters.GearboxConverter  GearboxConverter.   (Car_Rental.Converters.StatusCarConverter  StatusCarConverter��%t   &	        &	      &	 &     &	 9       5   
   6*     5   
   6!     5   
   6      5   
   6"   5      .��5      �  � RowDefinitions 5   
   �� 5       $��50 �6   �� 5!      .+�5$   
   � $��0��6   .+�5%      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5&      $
��Left=�5'      $��0��5(      .+�5)      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6   $��30��6-   $��30��69     plainTextColor3   
Foreground# [ 6D   �� 5+      -   5         ��Name$ SearchTextBox��5,      
�������$��13(�5-   '   $��24��65   $	��150��6A   
������ $��Medium"�6f   $��
Montserrat)�5.       �� 
CaretBrush# [ 6-   #��[ 6[   $��0,0,0,1q�5/      $��Center=�6/   $��5,5,0,0q�6Q   ��5,   ,   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�50   9   �� 52      -   5        $
��Rent��52      $	��100��6(   $��30��64   $��15,0,0,0q�6\   ��53      �� 54      
 �� 
TargetType"
 ��6    .�55      ��  �� Property � �� �� Value �#773DFF6;   �� 56       � �� 57   "   �� 58   &    �� 
TargetType" ��66   .R�59   *   �� $��30��61   $	��100��6=    �� CornerRadius$ 15��6I   #��z��6[   ._�5:   .   �� $��Center=�6?   $��Center=�6Z   5;   +   5<   '   5>       �� Triggers 5?      P� 5@   "    P� Property �@J�IsMouseOver P� Value . . �5A   &   ��  � �� �#836EFB6C   5B   #   5D      5F      �� 5G      -   5        $��Return��5G      $	��100��6*   $��30��66   $��15,0,0,0q�6`   ��5H      �� 5I      "
 ��6    .�5J      ��  � �� �#773DFF6;   �� 5K       � �� 5L   "   �� 5M   &   " ��66   .R�5N   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5O   .   �� $��Center=�6?   $��Center=�6Z   5P   +   5Q   '   5S       5T      P� 5U   "    �@J�IsMouseOver . . �5V   &   ��  � �� �#836EFB6C   5W   #   5Y      5[      �� 5^      -   5         ��Name$ FiltersButton��5^      $��Filters��60   $	��100��6B   $��30��6N   $��15,0,0,0q�6�   ��5_      �� 5`      "
 ��6    .�5a      ��  � �� �#773DFF6;   �� 5b       � �� 5c   "   �� 5d   &   " ��66   .R�5e   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5f   .   �� $��Center=�6?   $��Center=�6Z   5g   +   5h   '   5j       5k      P� 5l   "    �@J�IsMouseOver . . �5m   &   ��  � �� �#836EFB6C   5n   #   5p      5r      � 5u      -   5         �Name$ FiltersPopup��5u      $��Bottom=�5w       � AllowsTransparency .  � 	StaysOpen .  � PlacementTarget 5v      ��  �� ElementName$ FiltersButton��.��5z      �� 
�������
�������$��1q�6C    �� Padding$ 10q�6W   ._�5{      �� $ Vertical=�6%   .+�5|      �� $��	Available��6'   $��0,0,0,5q�6q    d� 	IsChecked 6;   �� *IsAvailableChecked+$	 TwoWay=�6q   �� 5}      $��Reserved��6'   $��0,0,0,5q�6o    6:   �� *IsReservedChecked+$	 TwoWay=�6o   �� 5~      $��Rented��6'   $��0,0,0,5q�6k    68   �� *IsRentedChecked+$	 TwoWay=�6k   �� 5      $��Maintenance��6'   $��0,0,0,5q�6u    6=   �� *IsMaintenanceChecked+$	 TwoWay=�6u   �� 5�      $��
In service��6'   $��0,0,0,5q�6r    6<   �� *IsInServiceChecked+$	 TwoWay=�6r   5�      5�      5�      5�      5�      �� 5�   
   $��1��6   ���#200F53$ 10��5�      $ 10q�5�      ._�5�      � .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ CarDataGrid��5�         ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$ *	 5�      ���#200F53   
IsReadOnly .    SelectionMode$ Single=�5�         AutoGenerateColumns .     RowBackground �#36257E    AlternatingRowBackground  �#2B1A69!   HeadersVisibility$! Column=�5�      "   GridLinesVisibility$
" None=�5�      $��0q�5�      $��Stretch=�5�      $��Stretch=�5�      ��5�      �� *FilteredCars+#   ColumnHeaderStyle# 5�      �� 5�      =
  7System.Windows.Controls.Primitives.DataGridColumnHeader"
 
 6    .�5�      ��  � ��
 ���� 6;   �� 5�       � ��
 �����6;   �� 5�       � ��$ 0,0,0,0q�68   �� 5�       � ��$ 
Montserrat)�6;   �� 5�       � ��$ 18(�69   �� 5�       � ��$ SemiBold"�6;   5�      $   	CellStyle$ 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"
  6    .�5�      ��  � ��
 �����6;   �� 5�       � ��$ 16(�69   �� 5�       � ��$ Center=�6B   5�      %   Columns% 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      ,  &System.Windows.Controls.DataGridColumn&   Header$& Image��61   '   Width$	' 160	 6@   (   CellTemplate( 5�      �� 5�   "   .R�5�   &   �� $	��150��6,   $	��100��68   $��UniformToFill=�5�   ,   $
��Left=�5�   ,   $��Center=�5�   ,   ��5�   ,   �� *	ImagePath+5�   ,   5�   #   5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $& Class��6-   $
' Auto	 6]   )   MinWidth$) 50Q�6j   1  +System.Windows.Controls.DataGridBoundColumn*   Binding* 6<   �� *VehicleClass+6j     5�      $& Brand��6-   $
' Auto	 6V   $	) 100Q�6c   * 6<   �� *Brand+6c     5�      $& Model��6-   $
' Auto	 6V   $) 70Q�6c   * 6<   �� *Model+6c     5�      $
& Year��6-   $
' Auto	 6^   $) 50Q�6k   * 6;   �� *ProductionYear+6k     5�      $& LicensePlate��6-   $
' Auto	 6d   $	) 110Q�6q   * 6C   �� *LicensePlate+6q     5�      $& 	Fuel Type��6-   $
' Auto	 6�   $) 90Q�6�   * 6@   �� *
FuelType++ �� 	Converter#+ [ 6�     5�      $& Gearbox��6-   $
' Auto	 6�   $	) 100Q�6�   * 6>   �� *	Gearbox+#+ [ 6�     5�      $& Color��6-   $
' Auto	 6V   $) 90Q�6c   * 6<   �� *Color+6c     5�      $& Mileage��6-   $
' Auto	 6Z   $) 80Q�6g   * 6>   �� *	Mileage+6g     5�      $& Status��6-   $
' Auto	 6�   $) 60Q�6�   * 6=   �� *	StatusCar+#+ [ 6�   5�      �� 5�      $��Brak wyników��6   
�������$��30(�5�      $��
Montserrat)�5�      $��Center=�5�      $��Center=�5�      y�5�      �� *FilteredCars.Count+#+ [  5�      5�      5�      5�      