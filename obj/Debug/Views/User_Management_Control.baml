   M S B A M L   `   `   `  ����E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  5      =#clr-namespace:Car_Rental.ConvertersCar_Rental.Converters  5      =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels  5	      .    (Car_Rental.Views.User_Management_Control   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      *localclr-namespace:Car_Rental.Views  5      .conv#clr-namespace:Car_Rental.Converters  5      ,vm#clr-namespace:Car_Rental.ViewModels  5	      $	��750��5      $	��300��5        � DataContext  5      3   -Car_Rental.ViewModels.UserManagementViewModel  5   
    � 	Resources 5      6   0Car_Rental.Converters.EmptyToVisibilityConverter   EmptyToVisibilityConverter-   'Car_Rental.Converters.FuelTypeConverter  FuelTypeConverter,   &Car_Rental.Converters.GearboxConverter  GearboxConverter.   (Car_Rental.Converters.StatusCarConverter  StatusCarConverter1   +Car_Rental.Converters.AccessToRoleConverter  AccessToRoleConverter��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6*     5   
   6!     5   
   6      5   
   6"     5   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5"   
   � $��0��6   .+�5#      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5$      $
��Left=�5%      $��0��5&      .+�5'      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6   $��30��6-   $��30��69     plainTextColor3   
Foreground# [ 6D   �� 5)      -   5         ��Name$ SearchTextBox��5*      
�������$��13(�5+   '   $��24��65   $	��250��6A   
������ $��Medium"�6f   $��
Montserrat)�5,       �� 
CaretBrush# [ 6-   #��[ 6[   $��0,0,0,1q�5-      $��Center=�6/   $��5,5,0,0q�6Q   ��5*   ,   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�5.   9   �� 50      -   5        $	��Add��50      $	��100��6'   $��30��63   $��15,0,0,0q�6[   ��51      �� 52      
 �� 
TargetType"
 ��6    .�53      ��  �� Property � �� �� Value �#773DFF6;   �� 54       � �� 55   "   �� 56   &    �� 
TargetType" ��66   .R�57   *   �� $��30��61   $	��100��6=    �� CornerRadius$ 15��6I   #��z��6[   ._�58   .   �� $��Center=�6?   $��Center=�6Z   59   +   5:   '   5<       �� Triggers 5=      P� 5>   "    P� Property �@J�IsMouseOver P� Value . . �5?   &   ��  � �� �#836EFB6C   5@   #   5B      5D      �� 5E      -   5        $
��Edit��5E      $	��100��6(   $��30��64   $��15,0,0,0q�6]   ��5F      �� 5G      "
 ��6    .�5H      ��  � �� �#773DFF6;   �� 5I       � �� 5J   "   �� 5K   &   " ��66   .R�5L   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5M   .   �� $��Center=�6?   $��Center=�6Z   5N   +   5O   '   5Q       5R      P� 5S   "    �@J�IsMouseOver . . �5T   &   ��  � �� �#836EFB6C   5U   #   5W      5Y      �� 5Z      -   5        $��Remove��5Z      $	��100��6*   $��30��66   $��15,0,0,0q�6a   ��5[      �� 5\      "
 ��6    .�5]      ��  � �� �#773DFF6;   �� 5^       � �� 5_   "   �� 5`   &   " ��66   .R�5a   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5b   .   �� $��Center=�6?   $��Center=�6Z   5c   +   5d   '   5f       5g      P� 5h   "    �@J�IsMouseOver . . �5i   &   ��  � �� �#836EFB6C   5j   #   5l      5n      5o      5q      �� 5r   
   $��1��6   ���#200F53$ 10��5t       �� Padding$ 10q�5u      ._�5w      � .+�5x      &	   System.Windows.Controls.DataGrid	  -   5         	 Name$ UserDataGrid��5x       	  AutoGenerateColumns .   	  SelectionMode$ Single=�5{       	  
IsReadOnly .  	  ColumnWidth5
  /System.Windows.Controls.DataGridLengthConverter$ *
 5~      ���#200F53 	  RowBackground �#36257E 	  AlternatingRowBackground �#2B1A69 	  HeadersVisibility$ Column=�5�       	  GridLinesVisibility$
 None=�5�      $��0q�5�      $��Stretch=�5�      $��Stretch=�5�      ��5y      �� *Users+ 	  ColumnHeaderStyle 5�      �� 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  6    .�5�      ��  � ��
 ���� 6;   �� 5�       � ��
 �����6;   �� 5�       � ��$ 0,0,0,0q�68   �� 5�       � ��$ 
Montserrat)�6;   �� 5�       � ��$ 18(�69   5�       	  	CellStyle 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"
  6    .�5�      ��  � ��$ 16(�69   �� 5�       � ��
 �����6;   5�       	  Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-       
IsReadOnly  . !   Width$! 50
 6f   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 69   �� *UserId+6f     5�      $ Nazwa użytkownika��6-   $! *
 6e   " 6H   �� *
Username+6e     5�      $ Imię��6-   $! *
 6T   " 6;   �� *Name+6T     5�      $ Nazwisko��6-   $! *
 6\   " 6?   �� *
LastName+6\     5�      $ Email��6-   $! *
 6V   " 6<   �� *Email+6V   4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      $ Admin��61   $! 60
 6[   " 6@   �� *Access+6[   5�      �� 5�      $��Brak wyników��6   
�������$��30(�5�      $��
Montserrat)�5�      $��Center=�5�      $��Center=�5�      y�5�      �� *Users.Count+# �� 	Converter## [  5�      5�      5�      5�      