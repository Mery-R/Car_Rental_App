   M S B A M L   `   `   `  ����   
Car_Rental&     Car_Rental.Views.Rent_Car_Window   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  
Rent a Car��$	��650��$	��500�����#f4f4f4 � WindowStartupLocation$ CenterScreen=� � 	Resources    RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius J� SnapsToDevicePixels��%�   &	        �� " ��.���  � �� �#0078D7��  � ��
 �������  � ��$
 Bold"���  � ��$ 0q���  � ��$
 10,5q���  � �� �� " ��.R��� #��z��$ 8�� . ._��� $��Center=�$��Center=�.��� $��20q�	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��
�������
 �� Padding$
 15q�$ 10��$��0,0,0,15q�._��� .+��� $��Car Details��$
��Bold"�$��18(����#333�� -    ��Name$ CarDetailsText��$��14(����#666$��0,5,0,0q��� $��1��
�������$
 15q�$ 10��$��0,0,0,15q�._��� .+��� $��Select Customer:��$��16(�$
��Bold"����#333�� -    ��Name$ CustomerComboBox�� �� DisplayMemberPath$ FullName�� �� SelectedValuePath$ 
CustomerId��$��0,10,0,0q�$��30���� -   $��Add New Customer��$��0,10,0,0q�#��[  �� $��2��
�������$
 15q�$ 10��$��0,0,0,15q�._��� .+��� $��Rental Period:��$��16(�$
��Bold"����#333��  �� Orientation$ 
Horizontal=�$��0,10,0,0q�$
��Left=�.+�(  "System.Windows.Controls.DatePicker  -   $��StartDatePicker��$	��120���� $
�� to ��$��Center=�$
��10,0q�  -   $��EndDatePicker��$	��120���� $��3��
�������$
 15q�$ 10��$��0,0,0,15q�._��� $ 
Horizontal=�.+��� $��Total Price:��$��16(�$
��Bold"����#333$��0,0,5,0q��� -   $ TotalPriceText��$��16(����#0078D7�� $��4��
�������$
 15q�$ 10��$��0,0,0,15q�._��� $ 
Horizontal=�.+��� $��Deposit:��$��16(�$
��Bold"����#333$��0,0,5,0q��� -   $ DepositText��$��16(����#0078D7�� -    ��Name$ GeneratePdfCheckBox��$��Generate PDF Agreement�� d� 	IsChecked$
 TrueY�$��5��$��Center=�$
��Left=�$��	10,0,0,70q��� $��5��$ 
Horizontal=�$��Center=�$��0,20,0,0q�.+��� -	   $��Confirm��$	��160��$��44��$��0,0,20,0q�#��[  ���#28a745�� -
   $��Cancel��$	��160��$��44��#��[  ���#dc3545