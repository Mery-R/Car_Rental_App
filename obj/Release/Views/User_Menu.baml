   M S B A M L   `   `   `  ���� E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels       Car_Rental.Views.User_Menu   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Car_Rental.Views     9	viewModel#clr-namespace:Car_Rental.ViewModels     X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp    � Title$  	User_Menu��$	��700��$
��1300��$	��500��$	��600�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency .  � DataContext )   #Car_Rental.ViewModels.MainViewModel   � 	Resources  �� DataType-   'Car_Rental.ViewModels.ShowCarsViewModel-   'Car_Rental.Views.Show_Cars_User_Control+   %Car_Rental.ViewModels.PricesViewModel)   #Car_Rental.Views.Price_List_Control,   &Car_Rental.ViewModels.HistoryViewModel&    Car_Rental.Views.History_Control7  1Car_Rental.ViewModels.CustomerManagementViewModel2	   ,Car_Rental.Views.Customer_Management_Control��%�   (��       *, +)(��      *, +)(�� $     *, +)(�� 6     *, +)�� "  .R�  �� "  .R�  �� "  .R�  �� "  .R�	  .����  �� CornerRadius$ 10��$��5q�����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.���    winBorderColor1
 � Color#
 [   � Offset$ 0Q��   winBorderColor2#
 [ $	 0.5Q��   winBorderColor3#
 [ $ 1Q�._��  � ColumnDefinitions �� $	��250 ��� $��* �.+��� $ 	10,0,0,10��$��0������ $	 0,0&�$	 1,0.7&�.���   secondaryBackColor1#
 [ $ 0Q��   secondaryBackColor2#
 [ $ 1Q�._��  � RowDefinitions �� $
��Auto ��� $	��330 ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$	��100��$��
40,30,0,40q�.+��� $��/Images/3.png��$	��100���� $��1��.+�	�   
menuButton#��[  
 color1
 � Tag# [  d� 	IsChecked$
 TrueY����� *ShowCarViewCommand+.���� $ 
Horizontal=�.+�!
  FontAwesome.Sharp.IconImage
  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$	 Car=�  menuButtonIcon#��[ ��   menuButtonText#��[ $��	Show cars��	� #��[  
	 color2# [	 ���� *PricesViewCommand+.���� $ 
Horizontal=�.+�
  $
 Tags=�#��[ �� #��[ $��Prices��	� #��[  

 color3# [
 ���� *HistoryViewCommand+.���� $ 
Horizontal=�.+�
  $ ClockRotateLeft=�#��[ �� #��[ $��History��	� #��[  
 color6# [ ���� *CustomerManagementViewCommand+.���� $ 
Horizontal=�.+�
  $ 
PeopleRoof=�#��[ �� #��[ $��	Customers���� $��2��$ 
Horizontal=�$��Bottom=�$��0,0,0,10q�.+�� $��10,10,10,10q�$��Bottom=� �� $	��180 ��� $��60 �.+��� $ 
Horizontal=�$��0��$��Bottom=�.+�A� $��50��$��50��#��[	 $��2��$��	10,0,10,0q�����  �� ImageSource$ /Images/AdminIcon.png����   titleColor3#��[ $��
Montserrat)�$��17(�$��Center=� J� Opacity$	 0.8Q�$
��Wrap=�$��CharacterEllipsis=�$	��110������ *CurrentUser.Username+�� -   $��1��  
iconButton#��[  
 color4# [ .��
  $ RightFromBracket=�  iconButtonIcon#��[ �� $ 	0,10,10,0��$��1������ $	 1,1&�$		 0,0&�.���   primaryBackColor1#
 [ $ 0Q��   primaryBackColor2#
 [ $ 1Q�._��  �� $��35 ��� $��35 ��� $��* �.+��� -    ��Name$ pnlControlBar��$��0��$ 
Horizontal=�$��RightToLeft=�
������ $��0,0,5,0q�$��35��$��Bottom=�.+��� -    ��Name$ btnClose��  controlButton#��[ # [ .��
  $ Xmark=�  controlButtonIcon#��[ �� -   $ btnMaximize��#��[ # [ .��
  $ Square=�#��[ �� -   $ btnMinimize��#��[  
 color8# [ .��
  $ WindowMinimize=�$��12��#��[ �� $��1��$ 
Horizontal=�$��Center=�.+�
  $��30��$��30��  titleColor2   
Foreground# [ $��	35,0,10,0q� �� *Icon+�� #��[ $��17(�$��
Montserrat)�$��Medium"�$��Center=����� *	Caption+�� $��2��$��25q����� *CurrentChildView+