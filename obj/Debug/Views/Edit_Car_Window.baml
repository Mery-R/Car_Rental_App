   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    
Car_RentalI3clr-namespace:Car_Rental.Models;assembly=Car_RentalCar_Rental.Models 5   	   &    Car_Rental.Views.Edit_Car_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Fmodels3clr-namespace:Car_Rental.Models;assembly=Car_Rental     5   	     � Title$  Edytuj samochód��5   	   $	��850��6!   $	��400��6.    � 
ResizeMode$ 	CanResize=�5   	    � WindowStyle$ SingleBorderWindow=�5   	    J� 	AllowDrop .  � 	Resources 5         BrandValues S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName  FuelTypeValues  GearboxValues  VehicleClassValues  ColorValues  CarStatusValues��%�  &	        &	 i     &	 �     &	 @    &	 �    &	     S� 5   
   $ 	GetValues��61   "  6H    5      M� 5      $ models:Brand��6   5      S� 5   
   $ 	GetValues��64   "  6K    5      M� 5      $ models:FuelType��6   5      S� 5   
   $ 	GetValues��63   "  6J    5      M� 5      $ models:Gearbox��6   5      S� 5   
   $ 	GetValues��68   "  6O    5      M� 5       $ models:VehicleClass��6   5"      S� 5$   
   $ 	GetValues��61   "  6H    5%      M� 5&      $ models:Color��6   5(      S� 5*   
   $ 	GetValues��65   "  6L    5+      M� 5,      $ models:CarStatus��6   5.      5/      .��51      �� .��52   
   �� $��10q�6   .+�54      �� $��Brand:��6   �� 55      -   5        	 ��Name$	 BrandComboBox��55      ��6.   �� 
 �� Source#
 [  �� 57      $��Model:��6   �� 58      -   5         ��Name$ ModelTextBox��58      �� 5:      $��Production year:��6   �� 5;      -   5        $	 ProductionYearComboBox��5;      �� 5=      $��License Plate:��6   �� 5>      -   5        $ LicensePlateTextBox��5>      �� 5@      $
��VIN:��6   �� 5A      -   5        $ 
VINTextBox��5A      �� 5C      $��Engine:��6   �� 5D      -   5        $ EngineTextBox��5D      �� 5F      $��
Fuel Type:��6   �� 5G      -   5        $	 FuelTypeComboBox��5G      ��61   �� #
 [ �� 5I      $��Gearbox:��6   �� 5J      -   5        $	 GearboxComboBox��5J      ��60   �� #
 [ �� 5L      $��Vehicle class:��6   �� 5M      -	   5        $	 VehicleClassComboBox��5M      ��65   �� #
 [ �� 5O      $��Color:��6   �� 5P      -
   5        $	 ColorComboBox��5P      ��6.   �� #
 [ �� 5R      $��Mileage:��6   �� 5S      -   5        $ MileageTextBox��5S      �� 5U      $��Status:��6   �� 5V      -   5        $	 StatusComboBox��5V      ��6/   �� #
 [ �� 5X      $��Price 1-3 days:��6   �� 5Y      -   5        $ DailyPrice13TextBox��5Y      �� 5[      $��Price 4-8 days:��6   �� 5\      -   5        $ DailyPrice48TextBox��5\      �� 5^      $��Price 9-15 days:��6   �� 5_      -   5        $ DailyPrice915TextBox��5_      �� 5a      $��Price 16-29 days:��6   �� 5b      -   5        $ DailyPrice1629TextBox��5b      �� 5d      $��Price 30+ days:��6   �� 5e      -   5        $ DailyPrice30PlusTextBox��5e      �� 5g      $��Weekend price:��6   �� 5h      -   5        $ WeekendPriceTextBox��5h      �� 5j      $��Deposit:��6   �� 5k      -   5        $ DepositTextBox��5k      �� 5m      $��Image:��6   �� 5n      .+�5o      �� -   5         ��Name$ ImageDropZone��5o      
�������$��1q�6C   $��80��6W    .  �� Padding$ 5q�6�   ._�5p      � .+�5q      �� -   5         ��Name$ PreviewImage��5q       $��Uniform=�66   $y�	Collapsed=�6H   �� 5r      -   5         ��Name$ DropHintText��5r   $   $+��%Przeciągnij i upuść zdjęcie tutaj��6:   $��Center=�5s   $   $��Center=�6A   
�������5t   $   5u      5v      �� 5w      -   5        $ ImageInfoText��5w      
��� � �$��12(�6F   $y�	Collapsed=�6T   $%��Zdjęcie załadowane pomyślnie��6k   5x      �� 5z       �� Orientation$ 
Horizontal=�6   $��0,10,0,0q�62   $��Center=�6D   .+�5{      �� -   5        $��Zapisz��5{      $��80��6*   65   �� 5|      -   5        $��Anuluj��5|      $��80��6*   $��10,0,0,0q�65   6G   5}      5      5�      5�      