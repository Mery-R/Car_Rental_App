   M S B A M L   `   `   `  ����E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  5      =#clr-namespace:Car_Rental.ConvertersCar_Rental.Converters  5      =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels  5	      2    ,Car_Rental.Views.Customer_Management_Control   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      *localclr-namespace:Car_Rental.Views  5      .conv#clr-namespace:Car_Rental.Converters  5      ,vm#clr-namespace:Car_Rental.ViewModels  5	      $	��750��5      $	��300��5        � DataContext  5      7  1Car_Rental.ViewModels.CustomerManagementViewModel  5   
    � 	Resources 5      6   0Car_Rental.Converters.EmptyToVisibilityConverter   EmptyToVisibilityConverter-   'Car_Rental.Converters.FuelTypeConverter  FuelTypeConverter,   &Car_Rental.Converters.GearboxConverter  GearboxConverter.   (Car_Rental.Converters.StatusCarConverter  StatusCarConverter��%t   &	        &	      &	 &     &	 9       5   
   6*     5   
   6!     5   
   6      5   
   6"   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5!   
   � $��0��6   .+�5"      ��  �� Orientation$ 
Horizontal=�6   $��Center=�5#      $
��Left=�5$      $��0��5%      .+�5&      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Search=�6   $��30��6-   $��30��69     plainTextColor3   
Foreground# [ 6D   �� 5(      -   5         ��Name$ SearchTextBox��5)      
�������$��13(�5*   '   $��24��65   $	��250��6A   
������ $��Medium"�6f   $��
Montserrat)�5+       �� 
CaretBrush# [ 6-   #��[ 6[   $��0,0,0,1q�5,      $��Center=�6/   $��5,5,0,0q�6Q   ��5)   ,   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�5-   9   �� 5/      -   5        $	��Add��5/      $	��100��6'   $��30��63   $��15,0,0,0q�6_   ��50      �� 51      
 �� 
TargetType"
 ��6    .�52      ��  �� Property � �� �� Value �#773DFF6;   �� 53       � �� 54   "   �� 55   &    �� 
TargetType" ��66   .R�56   *   �� $��30��61   $	��100��6=    �� CornerRadius$ 15��6I   #��z��6[   ._�57   .   �� $��Center=�6?   $��Center=�6Z   58   +   59   '   5;       �� Triggers 5<      P� 5=   "    P� Property �@J�IsMouseOver P� Value . . �5>   &   ��  � �� �#836EFB6C   5?   #   5A      5C      �� 5D      -   5        $
��Edit��5D      $	��100��6(   $��30��64   $��15,0,0,0q�6a   ��5E      �� 5F      "
 ��6    .�5G      ��  � �� �#773DFF6;   �� 5H       � �� 5I   "   �� 5J   &   " ��66   .R�5K   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5L   .   �� $��Center=�6?   $��Center=�6Z   5M   +   5N   '   5P       5Q      P� 5R   "    �@J�IsMouseOver . . �5S   &   ��  � �� �#836EFB6C   5T   #   5V      5X      �� 5Y      -   5        $��Remove��5Y      $	��100��6*   $��30��66   $��15,0,0,0q�6e   ��5Z      �� 5[      "
 ��6    .�5\      ��  � �� �#773DFF6;   �� 5]       � �� 5^   "   �� 5_   &   " ��66   .R�5`   *   �� $��30��61   $	��100��6=   $ 15��6I   #��z��6[   ._�5a   .   �� $��Center=�6?   $��Center=�6Z   5b   +   5c   '   5e       5f      P� 5g   "    �@J�IsMouseOver . . �5h   &   ��  � �� �#836EFB6C   5i   #   5k      5m      5n      5p      �� 5q   
   $��1��6   ���#200F53$ 10��5s       �� Padding$ 10q�5t      ._�5v      � .+�5w      &   System.Windows.Controls.DataGrid  -   5          Name$ CustomerDataGrid��5y         ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$ *	 5w      ���#200F53   
IsReadOnly .    SelectionMode$ Single=�5}         AutoGenerateColumns .     RowBackground �#36257E   AlternatingRowBackground �#2B1A69   HeadersVisibility$ Column=�5�         GridLinesVisibility$
 None=�5�      $��0q�5�      $��Stretch=�5�      $��Stretch=�5�      ��5z      �� *	Customers+   ColumnHeaderStyle 5�      �� 5�      =
  7System.Windows.Controls.Primitives.DataGridColumnHeader"
 
 6    .�5�      ��  � ��
 ���� 6;   �� 5�       � ��
 �����6;   �� 5�       � ��$ 0,0,0,0q�68   �� 5�       � ��$ 
Montserrat)�6;   �� 5�       � ��$ 18(�69   5�         	CellStyle 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"
  6    .�5�      ��  � ��$ 16(�69   �� 5�       � ��
 �����6;   5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6-       Width$
  Auto	 6Y   !   MinWidth$! 70Q�6f   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6;   �� *	FirstName+6f     5�      $ Surname��6-   $
  Auto	 6[   $! 90Q�6h   " 6>   �� *
LastName+6h     5�      $ Email��6-   $
  Auto	 6V   $	! 100Q�6c   " 6<   �� *Email+6c     5�      $ Phone��6-   $
  Auto	 6V   $	! 100Q�6c   " 6<   �� *Phone+6c     5�      $ Pesel��6-   $
  Auto	 6V   $	! 100Q�6c   " 6<   �� *PESEL+6c     5�      $ License number��6-   $
  Auto	 6m   $	! 140Q�6z   " 6E   �� *DriverLicenseNumber+6z     5�      $ Date of birth��6-   $
  Auto	 6d   $	! 120Q�6q   " 6D   �� *DateOfBirth+6q     5�      $ Street��6-   $
  Auto	 6X   $! 80Q�6e   " 6=   �� *Street+6e     5�      $
 City��6-   $
  Auto	 6T   $! 60Q�6a   " 6;   �� *City+6a     5�      $ Postal code��6-   $
  Auto	 6a   $! 60Q�6n   " 6B   �� *
PostalCode+6n   5�      �� 5�      $��Brak wyników��6   
�������$��30(�5�      $��
Montserrat)�5�      $��Center=�5�      $��Center=�5�      y�5�      �� *Customers.Count+# �� 	Converter## [  5�      5�      5�      5�      