   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   
Car_RentalI3clr-namespace:Car_Rental.Models;assembly=Car_RentalCar_Rental.Models )   #Car_Rental.Views.Service_Car_Window   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6sys&clr-namespace:System;assembly=mscorlib     Fmodels3clr-namespace:Car_Rental.Models;assembly=Car_Rental       � Title$  Add Service��$	��500��$	��600�� � WindowStartupLocation$ CenterScreen=� � 	Resources    ServiceStatus S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName��%H   &	        S� $ 	GetValues��"   M� $ models:ServiceStatus��.��� $��20q�.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��0,0,0,15q�.+��� -    ��Name$ CarInfoTextBlock��$
��Bold"�$��16(��� $��1��$��0,0,0,15q�.+��� $��Start Date:��(  "System.Windows.Controls.DatePicker  -   	  Name$	 StartDatePicker��$��0,5,0,10q��� $��	End Date:��  -   $	 EndDatePicker��$��0,5,0,10q��� $��Status:���� -   
 ��Name$
 StatusComboBox��$��0,5,0,10q�����  �� Source# [  �� $��Description:���� -    ��Name$ DescriptionTextBox��$	��100�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��0,5,0,10q��� $��4�� �� Orientation$ 
Horizontal=�$��Right=�$��0,15,0,0q�.+��� -   $��Add Service��$	��120��$��0,0,10,0q��� -   $��Close��$��80��