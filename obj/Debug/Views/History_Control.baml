   M S B A M L   `   `   `  ����E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  5      =#clr-namespace:Car_Rental.ConvertersCar_Rental.Converters  5      =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels  5	      &     Car_Rental.Views.History_Control   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      *localclr-namespace:Car_Rental.Views  5      .conv#clr-namespace:Car_Rental.Converters  5      ,vm#clr-namespace:Car_Rental.ViewModels  5	      $	��750��5      $	��500��5        � DataContext  5      ,   &Car_Rental.ViewModels.HistoryViewModel  5   
    � 	Resources 5      6   0Car_Rental.Converters.EmptyToVisibilityConverter   EmptyToVisibilityConverter-   'Car_Rental.Converters.FuelTypeConverter  FuelTypeConverter,   &Car_Rental.Converters.GearboxConverter  GearboxConverter.   (Car_Rental.Converters.StatusCarConverter  StatusCarConverter6   0Car_Rental.Converters.StatusReservationConverter  StatusReservationConverter��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6*     5   
   6!     5   
   6      5   
   6"     5   
   6*   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5"   
   � $��0��6   .+�5#      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5$      $
��Left=�5%      $��0��5&      .+�5'      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6   $��30��6-   $��30��69     plainTextColor3   
Foreground# [ 6D   �� 5)      -   5         ��Name$ SearchTextBox��5*      
�������$��13(�5+   '   $��24��65   $	��250��6A   
������ $��Medium"�6f   $��
Montserrat)�5,       �� 
CaretBrush# [ 6-   #��[ 6[   $��0,0,0,1q�5-      $��Center=�6/   $��5,5,0,0q�6Q   ��5*   ,   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�5.   9   �� 50      -   5        $
��Edit��50      $	��100��6(   $��30��64   $��15,0,0,0q�6`   ��51      �� 52      
 �� 
TargetType"
 ��6    .�53      ��  �� Property � �� �� Value �#773DFF6;   �� 54       � �� 55   "   �� 56   &    �� 
TargetType" ��66   .R�57   *   �� $��30��61   $	��100��6=    �� CornerRadius$ 15��6I   #��z��6[   ._�58   .   �� $��Center=�6?   $��Center=�6Z   59   +   5:   '   5<       �� Triggers 5=      P� 5>   "    P� Property �@J�IsMouseOver P� Value . . �5?   &   ��  � �� �#836EFB6C   5@   #   5B      5D      �� 5E      -   5        $��Delete��5E      $	��100��6*   $��30��66   $��15,0,0,0q�6d   ��5F      �� 5G      "
 ��6    .�5H      ��  � �� �#773DFF6;   �� 5I       � �� 5J   "   �� 5K   &   " ��66   .R�5L   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5M   .   �� $��Center=�6?   $��Center=�6Z   5N   +   5O   '   5Q       5R      P� 5S   "    �@J�IsMouseOver . . �5T   &   ��  � �� �#836EFB6C   5U   #   5W      5Y      �� 5[      -   5         ��Name$ ShowReservationsButton��5[   0   $��Reservations��6   $	��100��6P   $��30��6\   $��15,0,0,0q�6�   ��5\      �� 5]      "
 ��6    .�5^      ��  � �� �#773DFF6;   �� 5_       � �� 5`   "   �� 5a   &   " ��66   .R�5b   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5c   .   �� $��Center=�6?   $��Center=�6Z   5d   +   5e   '   5g       5h      P� 5i   "    �@J�IsMouseOver . . �5j   &   ��  � �� �#836EFB6C   5k   #   5m      5o      �� 5q      -   5        $ ShowServicesButton��5q   3   $��Service History��6   $	��100��6O   $��30��6[   $��15,0,0,0q�6�   ��5r      �� 5s      "
 ��6    .�5t      ��  � �� �#773DFF6;   �� 5u       � �� 5v   "   �� 5w   &   " ��66   .R�5x   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5y   .   �� $��Center=�6?   $��Center=�6Z   5z   +   5{   '   5}       5~      P� 5   "    �@J�IsMouseOver . . �5�   &   ��  � �� �#836EFB6C   5�   #   5�      5�      5�      5�      �� 5�   
   $��1��6   ���#200F53$ 10��63    �� Padding$ 10q�6E   ._�5�      � .+�5�      �� -   5         ��Name$ ReservationsContent��5�      $y�Visible=�6:   .+�5�      &	   System.Windows.Controls.DataGrid	  -   5         	 Name$ ReservationsDataGrid��5�       	  AutoGenerateColumns .  $	��500��6Y   $��5q�6f   $��Stretch=�5�      $	��Top=�6=   ���#200F53 	  
IsReadOnly .  	  SelectionMode$ Single=�5�   F    	  HeadersVisibility$ Column=�6]    	  GridLinesVisibility$
 None=�5�   !   $��0q�6<    	  RowBackground �#36257E 	  AlternatingRowBackground �#2B1A69��5�   U   �� *Reservations+ 	  ColumnHeaderStyle 5�      �� 5�      =
  7System.Windows.Controls.Primitives.DataGridColumnHeader"
 
 6$   .�5�   "   ��  � ��
 ���� 6?   �� 5�   "    � ��
 �����6?   �� 5�   "    � ��$ 0,0,0,0q�6<   �� 5�   "    � ��$ 
Montserrat)�6?   �� 5�   "    � ��$ 18(�6=   5�       	  	CellStyle 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"
  6$   .�5�   "   ��  � ��$ 16(�6=   �� 5�   "    � ��
 �����6?   5�       	  Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn    Header$  ID��61   !   Width5  /System.Windows.Controls.DataGridLengthConverter$
! 0.3* 6_   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6=   �� *ReservationId+6_     5�      $  Plate��61   $! * 6a   #   MinWidth$# 80Q�6k   " 6@   �� *LicensePlate+6k     5�      $
  User��61   $! * 6\   $# 90Q�6f   " 6?   �� *
UserName+6f     5�      $  Customer��61   $
! 1.1* 6h   $	# 100Q�6u   " 6C   �� *CustomerFullName+6u     5�      $  PESEL��61   $
! 1.5* 6b   $	# 100Q�6o   " 6@   �� *CustomerPESEL+6o     5�      $  
Start Date��61   $! 2* 6c   $	# 170Q�6n   " 6E   �� *	StartDate+6n     5�      $  End Date��61   $! 2* 6_   $	# 170Q�6j   " 6C   �� *	EndDate+6j     5�      $  Status��61   $! * 6�   " 6A   �� *StatusReservation+$ �� 	Converter#$ [ 6�     5�      $  Total Price��61   $! * 6e   $# 90Q�6o   " 6F   �� *
TotalPrice+6o   5�      �� 5�      $��Brak wyników��6    
�������$��30(�5�       $��
Montserrat)�5�       $��Center=�5�       $��Center=�5�       y�5�       �� *Reservations.Count+#$ [  5�      �� 5�      -   5        $ ServicesContent��5�      $y�	Collapsed=�66   .+�5�      	  -	   5        $ ServicesDataGrid��5�       .  $	��300��6U   $��5q�6b   $��Stretch=�5�      $	��Top=�6=   ���#200F53 . $ Single=�5�   F   $ Column=�6]   $
 None=�5�   !   $��0q�6<   
 �����
 �������5�   U   �� *
Services+ 5�      �� 5�      "
 
 6$   .�5�   "   ��  � ��
 ���� 6?   �� 5�   "    � ��
 �����6?   �� 5�   "    � ��$ 0,0,0,0q�6<   �� 5�   "    � ��$ 
Montserrat)�6?   �� 5�   "    � ��$ 18(�6=   5�       5�      �� 5�      "
  6$   .�5�   "   ��  � ��$ 16(�6=   5�       5�        5�      $  ID��61   $
! 0.3* 6[   " 6=   �� *	ServiceId+6[     5�      $  Plate��61   $! * 6a   " 6@   �� *LicensePlate+6a     5�      $  
Start Date��61   $! 2* 6c   " 6E   �� *	StartDate+6c     5�      $  End Date��61   $! 2* 6_   " 6C   �� *	EndDate+6_     5�      $  Description��61   $! 4* 6f   " 6F   �� *Description+6f     5�      $
  Cost��61   $! * 6_   " 6?   �� *ServiceCost+6_   5�      �� 5�      $��Brak wyników��6    
�������$��30(�5�       $��
Montserrat)�5�       $��Center=�5�       $��Center=�5�       y�5�       �� *Services.Count+#$ [  5�      5�      5�      5�      5�      