   M S B A M L   `   `   `  ���� E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Car_Rental
Car_Rental  E'clr-namespace:Car_Rental.CustomControlsCar_Rental.CustomControls  =#clr-namespace:Car_Rental.ViewModelsCar_Rental.ViewModels      Car_Rental.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Car_Rental     Bcustomcontrols'clr-namespace:Car_Rental.CustomControls     9	viewModel#clr-namespace:Car_Rental.ViewModels     -   
������   � AllowsTransparency  .  � WindowStyle$
 None=� � Title$ 
MainWindow��$	��450��$	��800�� � DataContext *   $Car_Rental.ViewModels.LoginViewModel   � 	Resources     BooleanToVisibilityConverter��%   &	        �� y���  �� Path$ IsViewVisible� �� Mode$ TwoWay=� �� 	Converter# [  .��� $	��200��$	��300��.+���  �� CornerRadius$ 10��$��5q����� 	 �� EndPoint$	 0.5,1&�
 �� 
StartPoint$
 0.5,0&�.���  � Color$ Black��� $ 
BlueViolet�� � Offset$	 1.5Q����� $		 1,1&�$	
 0,0&�.��� $ Violet��$	 0.2Q�� $
 Blue��$ 1Q��� $ 10��$��5q� J� Opacity$	 0.5Q�����  �� ImageSource$ /Images/background.jpg���  � RowDefinitions �� $��30 ��� $��* �.+��  � ColumnDefinitions �� $��* ��� $��25 ��� $��25 ��� $��5 �.+��� $��0��$��Log In��$��15(�$��Center=�$��10,0,0,0q�
��������� -    ��Name$ Button_Minimize��$��1��$��-��$��16(�
���   �$��0q�$��0,5,0,0q�����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ����� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ���������  �� 
TargetType" ��.R��� $��18��$��18��#��z��$ 9��._��� $��Center=�$��Center=� � Cursor$ Arrow��$��0,-5,0,0q��� -   $ Button_Close��$��2��$��16(�
���   �$��0,5,5,0q�$��x��$��1,1,1,1q�$ Arrow�� J� RenderTransformOrigin$ 0.5,0&����� " ��.���  � ��
 ����� P�  �@J�IsMouseOver . . ���  � ��
 ��������� " ��.R��� $��18��$��18��#��z��$ 9��._��� $��Center=�$��Center=�$ Arrow��$��0,-5,0,0q��� $	��250��$��2�� �� Orientation$ Vertical=�$��	0,-60,0,0q�$��Center=�$��Center=�.+��� $��/Images/3.png��$	��150��$	��150���� $��Welcome to Car Rental��$��	0,-20,0,0q�$��20(�$
��Bold"�
�������$��30��$��Center=��� $��Username��$��14(�
��������� -    ��Name$ Username��$��25,0,0,0q�$��14(�$��0,0,0,1q�
�������
�������$��Center=� �� TextWrapping$
 Wrap=�$	��250��$��25��$��0,5,0,0q����� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.������ $ /Images/user_icon.png�� j� Stretch$
 None=�  j� 
AlignmentX$
  Left=�.���� $��Password��$��0,5,0,0q�$��14(�
�������3   -Car_Rental.CustomControls.BindablePasswordBox  $��25��$��0,5,0,0q�!   Password! �� *
Password+$ TwoWay=�$ PropertyChanged=��� $��Center=�$��0,10,0,0q�$��12(�
���  ��$
��Wrap=����� *ErrorMessage+�� -   $ Login��$��LOG IN��$��Center=�$��0,10,0,0q�$��35��$	��150��$��20(�$
��Bold"�
�������
�������" �� 	IsDefault" . ���� *LoginCommand+��Z� 