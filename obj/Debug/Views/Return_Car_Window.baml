   M S B A M L   `   `   `  ����  
Car_Rental(    "Car_Rental.Views.Return_Car_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Return Car��5   	   $	��710��5   	   $	��700��6    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#F0F2F5.��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��10 �6   �� 5      $��70 �6   �� 5      $	��120 �6   �� 5      $	��320 �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $��
Return Car��6   $��24(�6*   $
��Bold"�68   ���#3336J   5      �� 5   
   $��1��6   $
��0,10q�6!   �� 5   
   $��2��6   $ Vertical=�6"   $��0,0,0,10q�69   .+�5      �� $��Reservation to return:��6   $��SemiBold"�66   $��0,0,0,5q�6L   �� 5      -   5        $��ReservationComboBox��5       �� DisplayMemberPath$ DisplayInfo��5       �� SelectedValuePath$ ReservationId��5      $��30��5!      5"      � 5%   
   $��3��6   $��0,0,0,15q�6    � ColumnDefinitions 5&      �� 5'      $��* �6#   �� 5(      $��* �6#    5*      �� 5+      $
��Auto �6    �� 5,      $
��Auto �6    .+�50      �� $��0��6   $��0��6&   $��	0,0,10,10q�66   .+�51      �� $��Car Details��6   $��SemiBold"�6/   �� 52      -   5        $��CarDetailsText��52      $
��Wrap=�62   $	��0,2q�6F   53      �� 56      $��0��6   $��1��6&   $��	10,0,0,10q�66   .+�57      �� $��Customer��6   $��SemiBold"�6,   �� 58      -   5        $��CustomerText��58      $
��Wrap=�60   $	��0,2q�6D   59      �� 5<      $��1��6   $��0��6&   $��0,0,10,0q�66   .+�5=      �� $��Return Time��6   $��SemiBold"�6/   �� 5>      $ 
Horizontal=�6   .+�5?      �� -   5        $��CurrentDateTimeText��5?       $��Center=�6;   �� 5@      -   5        $	��⟳��5@      $��24��5A      $��24��6(   $��5,0,0,0q�5B      $��0q�5D      5E      5F      �� 5I      $��1��6   $��1��6&   $��10,0,0,0q�66   .+�5J      �� $��Mileage (km)��6   $��SemiBold"�60   �� 5K      -   5        $��MileageTextBox��5K      $��30��60   5L      5M      �� 5P   
   $��4��6   $��Damage Marking (optional)��6!   $��SemiBold"�6B   $��0,0,0,5q�6X   �� 5R   
   $��4��6   
������� �� CornerRadius$ 8��5T      	 �� Padding$	 10q�5U      ���#DDD$��1q�5W      ._�5X      �� -   5        
 ��Name$
 	ImageTabs��5X       �� SelectedIndex$ 0��5Y      $	��290��5Z      $��Stretch=�5[      .@�5\      �� $��Front��6   .��5]      �� -   5         ��Name$ FrontCanvas��5]      ���#FAFAFA}�. .+�5`      �� -	   5        $��/Images/front.jpg��5`       $��Uniform=�5a       ��5b       �� *ActualWidth+ �� ElementName$ FrontCanvas����5c       �� *ActualHeight+$ FrontCanvas��5d       5e      5f      �� 5g      $
��Back��6   .��5h      �� -
   5        $ 
BackCanvas��5h      ���#FAFAFA}�. .+�5i      �� -   5        $��/Images/back.jpg��5i       $��Uniform=�5j       ��5k       �� *ActualWidth+$ FrontCanvas����5l       �� *ActualHeight+$ FrontCanvas��5m       5n      5o      �� 5p      $
��Left��6   .��5q      �� -   5        $ 
LeftCanvas��5q      ���#FAFAFA}�. .+�5r      �� -   5        $��/Images/left.png��5r       $��UniformToFill=�5s       ��5t       �� *ActualWidth+$ FrontCanvas����5u       �� *ActualHeight+$ FrontCanvas��5v       5w      5x      �� 5y      $��Right��6   .��5z      �� -   5        $ RightCanvas��5z      ���#FAFAFA}�. .+�5{      �� -   5        $��/Images/right.png��5{       $��UniformToFill=�5|       ��5}       �� *ActualWidth+$ FrontCanvas����5~       �� *ActualHeight+$ FrontCanvas��5       5�      5�      5�      5�      � 5�   
   -   5         �Name$ DamagePopup��5�      $��Mouse=�5�       � 	StaysOpen .  .��5�      �� 
����������#CCC$��1q�5�      $ 6��5�      $	 10q�5�      ._�5�      �� .+�5�      �� -   5        $��DamageTypeComboBox��5�      $��30��5�      $��0,0,0,5q�5�      .@�5�      �� $��Scratch��6'   �� 5�      $
��Dent��6'   �� 5�      $
��Chip��6'   �� 5�      $��Crack��6'   �� 5�      $��Other��6'   5�      �� 5�      -   5         ��Name$ DamageNoteTextBox��5�      $	��200��5�      $��60��5�       �� TextWrapping$
 Wrap=�5�       �� AcceptsReturn . $��0,0,0,5q�5�      �� 5�      -   5        $	��Add��5�      $	��100��5�      $��30��5�      $��Right=�5�      5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ GeneratePdfCheckBox��5�      $��Generate PDF Agreement��60    d� 	IsChecked$
 TrueY�6Q   $��5��6b   $��Center=�6o   $
��Left=�6�   $��	10,0,0,70q�6�   �� 5�   
   $��5��6   $ 
Horizontal=�5�      $��Center=�5�      $��0,15,0,0q�5�      .+�5�      �� -   5        $��Confirm return��5�      $	��140��5�      $��36��6!   $��5q�5�      ���#28A745
�������$��SemiBold"�5�      �� 5�      -   5        $��Cancel��5�      $	��140��5�      $��36��6!   $��5q�5�      ���#DC3545
�������$��SemiBold"�5�      5�      5�      5�      