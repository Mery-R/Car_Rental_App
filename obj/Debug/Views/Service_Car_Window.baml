   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    
Car_RentalI3clr-namespace:Car_Rental.Models;assembly=Car_RentalCar_Rental.Models 5   	   )   #Car_Rental.Views.Service_Car_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Fmodels3clr-namespace:Car_Rental.Models;assembly=Car_Rental     5   	     � Title$  Add Service��5   	   $	��500��6   $	��600��6*    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5         ServiceStatus S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName��%�   &	        S� 5
   
   $ 	GetValues��5      "  5       5      M� 5      $ models:ServiceStatus��6   5      5      .��5      � $��20q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   $��0,0,0,15q�6&   .+�5       �� -   5         ��Name$ CarInfoTextBlock��5       $
��Bold"�66   $��16(�6H   5!      �� 5$      $��1��6   $��0,0,0,15q�6&   .+�5%      �� $��Start Date:��6   (  "System.Windows.Controls.DatePicker  5&      -   5        	  Name$	 StartDatePicker��5&      $��0,5,0,10q�66   �� 5(      $��	End Date:��6     5)      -   5        $	 EndDatePicker��5)      $��0,5,0,10q�64   �� 5+      $��Status:��6   �� 5,      -   5        
 ��Name$
 StatusComboBox��5,      $��0,5,0,10q�63   ��6E   ��  �� Source# [  �� 5.      $��Description:��6   �� 5/      -   5         ��Name$ DescriptionTextBox��5/      $	��100��66    �� TextWrapping$
 Wrap=�6C    �� AcceptsReturn . $��0,5,0,10q�6l   50      �� 53      $��4��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   $��0,15,0,0q�6[   .+�54      �� -   5        $��Add Service��54      $	��120��6/   $��0,0,10,0q�6;   6M   �� 55      -   5        $��Close��55      $��80��6)   64   56      57      58      59      