   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    
Car_RentalI3clr-namespace:Car_Rental.Models;assembly=Car_RentalCar_Rental.Models 5   	   %   Car_Rental.Views.Add_Car_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Fmodels3clr-namespace:Car_Rental.Models;assembly=Car_Rental     5   	     � Title$  Dodaj samochód��5   	   $	��850��6    $	��400��6-    � 
ResizeMode$ 	CanResize=�5   	    � WindowStyle$ SingleBorderWindow=�5   	    J� 	AllowDrop .  � 	Resources 5         BrandValues S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName  FuelTypeValues  GearboxValues  VehicleClassValues  ColorValues  CarStatusValues��%�  &	        &	 q     &	 �     &	 H    &	 �    &	 !    S� 5   
   $ 	GetValues��5      "  5       5      M� 5      $ models:Brand��6   5      S� 5   
   $ 	GetValues��64   "  6K    5      M� 5      $ models:FuelType��6   5      S� 5   
   $ 	GetValues��63   "  6J    5      M� 5      $ models:Gearbox��6   5       S� 5"   
   $ 	GetValues��68   "  6O    5#      M� 5$      $ models:VehicleClass��6   5&      S� 5(   
   $ 	GetValues��61   "  6H    5)      M� 5*      $ models:Color��6   5,      S� 5.   
   $ 	GetValues��65   "  6L    5/      M� 50      $ models:CarStatus��6   52      53      .��55      �� .��56   
   �� $��10q�6   .+�58      �� $��Brand:��6   �� 59      -   5        	 ��Name$	 BrandComboBox��59      ��6.   �� 
 �� Source#
 [  �� 5;      $��Model:��6   �� 5<      -   5         ��Name$ ModelTextBox��5<      �� 5>      $��Production year:��6   �� 5?      -   5        $	 ProductionYearComboBox��5?      �� 5A      $��License Plate:��6   �� 5B      -   5        $ LicensePlateTextBox��5B      �� 5D      $
��VIN:��6   �� 5E      -   5        $ 
VINTextBox��5E      �� 5G      $��Engine:��6   �� 5H      -   5        $ EngineTextBox��5H      �� 5J      $��
Fuel Type:��6   �� 5K      -   5        $	 FuelTypeComboBox��5K      ��61   �� #
 [ �� 5M      $��Gearbox:��6   �� 5N      -   5        $	 GearboxComboBox��5N      ��60   �� #
 [ �� 5P      $��Vehicle class:��6   �� 5Q      -	   5        $	 VehicleClassComboBox��5Q      ��65   �� #
 [ �� 5S      $��Color:��6   �� 5T      -
   5        $	 ColorComboBox��5T      ��6.   �� #
 [ �� 5V      $��Mileage:��6   �� 5W      -   5        $ MileageTextBox��5W      �� 5Y      $��Status:��6   �� 5Z      -   5        $	 StatusComboBox��5Z      ��6/   �� #
 [ �� 5\      $��Price 1-3 days:��6   �� 5]      -   5        $ DailyPrice13TextBox��5]      �� 5_      $��Price 4-8 days:��6   �� 5`      -   5        $ DailyPrice48TextBox��5`      �� 5b      $��Price 9-15 days:��6   �� 5c      -   5        $ DailyPrice915TextBox��5c      �� 5e      $��Price 16-29 days:��6   �� 5f      -   5        $ DailyPrice1629TextBox��5f      �� 5h      $��Price 30+ days:��6   �� 5i      -   5        $ DailyPrice30PlusTextBox��5i      �� 5k      $��Weekend price:��6   �� 5l      -   5        $ WeekendPriceTextBox��5l      �� 5n      $��Deposit:��6   �� 5o      -   5        $ DepositTextBox��5o      �� 5q      $��Image:��6   �� 5r      .+�5s      �� -   5         ��Name$ ImageDropZone��5s      
�������$��1q�6C   $��80��6W    .  �� Padding$ 5q�6�   ._�5t      � .+�5u      �� -   5         ��Name$ PreviewImage��5u       $��Uniform=�66   $y�	Collapsed=�6H   �� 5v      -   5         ��Name$ DropHintText��5v   $   $+��%Przeciągnij i upuść zdjęcie tutaj��6:   $��Center=�5w      $��Center=�65   
�������5x      5y      5z      �� 5{      -   5        $ ImageInfoText��5{      
��� � �$��12(�6F   $y�	Collapsed=�6T   $%��Zdjęcie załadowane pomyślnie��6k   5|      �� 5       �� Orientation$ 
Horizontal=�6   $��0,10,0,0q�62   $��Center=�6D   .+�5�      �� -   5        $��Zapisz��5�      $��80��6*   65   �� 5�      -   5        $��Anuluj��5�      $��80��6*   $��10,0,0,0q�65   6G   5�      5�      5�      5�      