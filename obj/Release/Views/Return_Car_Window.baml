   M S B A M L   `   `   `  ����   
Car_Rental(    "Car_Rental.Views.Return_Car_Window   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
Return Car��$	��710��$	��700�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=����#F0F2F5.��� $��20q� � RowDefinitions �� $��40 ��� $��10 ��� $��70 ��� $	��120 ��� $	��320 ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��
Return Car��$��24(�$
��Bold"����#333�� $��1��$
��0,10q��� $��2��$ Vertical=�$��0,0,0,10q�.+��� $��Reservation to return:��$��SemiBold"�$��0,0,0,5q��� -   $��ReservationComboBox�� �� DisplayMemberPath$ DisplayInfo�� �� SelectedValuePath$ ReservationId��$��30��� $��3��$��0,0,0,15q� � ColumnDefinitions �� $��* ��� $��* � �� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��	0,0,10,10q�.+��� $��Car Details��$��SemiBold"��� -   $��CarDetailsText��$
��Wrap=�$	��0,2q��� $��0��$��1��$��	10,0,0,10q�.+��� $��Customer��$��SemiBold"��� -   $��CustomerText��$
��Wrap=�$	��0,2q��� $��1��$��0��$��0,0,10,0q�.+��� $��Return Time��$��SemiBold"��� $ 
Horizontal=�.+��� -   $��CurrentDateTimeText��$��Center=��� -   $	��⟳��$��24��$��24��$��5,0,0,0q�$��0q��� $��1��$��1��$��10,0,0,0q�.+��� $��Mileage (km)��$��SemiBold"��� -   $��MileageTextBox��$��30���� $��4��$��Damage Marking (optional)��$��SemiBold"�$��0,0,0,5q��� $��4��
������� �� CornerRadius$ 8��	 �� Padding$	 10q����#DDD$��1q�._��� -   
 ��Name$
 	ImageTabs�� �� SelectedIndex$ 0��$	��290��$��Stretch=�.@��� $��Front��.���� -    ��Name$ FrontCanvas�����#FAFAFA}�. .+��� -	   $��/Images/front.jpg��$��Uniform=����� *ActualWidth+ �� ElementName$ FrontCanvas������ *ActualHeight+$ FrontCanvas���� $
��Back��.���� -
   $ 
BackCanvas�����#FAFAFA}�. .+��� -   $��/Images/back.jpg��$��Uniform=����� *ActualWidth+$ FrontCanvas������ *ActualHeight+$ FrontCanvas���� $
��Left��.���� -   $ 
LeftCanvas�����#FAFAFA}�. .+��� -   $��/Images/left.png��$��UniformToFill=����� *ActualWidth+$ FrontCanvas������ *ActualHeight+$ FrontCanvas���� $��Right��.���� -   $ RightCanvas�����#FAFAFA}�. .+��� -   $��/Images/right.png��$��UniformToFill=����� *ActualWidth+$ FrontCanvas������ *ActualHeight+$ FrontCanvas��� -    �Name$ DamagePopup��$��Mouse=� � 	StaysOpen .  .���� 
����������#CCC$��1q�$ 6��$	 10q�._��� .+��� -   $��DamageTypeComboBox��$��30��$��0,0,0,5q�.@��� $��Scratch���� $
��Dent���� $
��Chip���� $��Crack���� $��Other���� -    ��Name$ DamageNoteTextBox��$	��200��$��60�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��0,0,0,5q��� -   $	��Add��$	��100��$��30��$��Right=��� -    ��Name$ GeneratePdfCheckBox��$��Generate PDF Agreement�� d� 	IsChecked$
 TrueY�$��5��$��Center=�$
��Left=�$��	10,0,0,70q��� $��5��$ 
Horizontal=�$��Center=�$��0,15,0,0q�.+��� -   $��Confirm return��$	��140��$��36��$��5q����#28A745
�������$��SemiBold"��� -   $��Cancel��$	��140��$��36��$��5q����#DC3545
�������$��SemiBold"�