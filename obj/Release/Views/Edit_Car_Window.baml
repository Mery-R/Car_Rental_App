   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   
Car_RentalI3clr-namespace:Car_Rental.Models;assembly=Car_RentalCar_Rental.Models &    Car_Rental.Views.Edit_Car_Window   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6sys&clr-namespace:System;assembly=mscorlib     Fmodels3clr-namespace:Car_Rental.Models;assembly=Car_Rental       � Title$  Edytuj samochód��$	��850��$	��400�� � 
ResizeMode$ 	CanResize=� � WindowStyle$ SingleBorderWindow=� J� 	AllowDrop .  � 	Resources    BrandValues S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName  FuelTypeValues  GearboxValues  VehicleClassValues  ColorValues  CarStatusValues��%�  &	        &	 6     &	 o     &	 �     &	 �     &	     S� $ 	GetValues��"   M� $ models:Brand��S� $ 	GetValues��"   M� $ models:FuelType��S� $ 	GetValues��"   M� $ models:Gearbox��S� $ 	GetValues��"   M� $ models:VehicleClass��S� $ 	GetValues��"   M� $ models:Color��S� $ 	GetValues��"   M� $ models:CarStatus��.���� .���� $��10q�.+��� $��Brand:���� -   	 ��Name$	 BrandComboBox������ 
 �� Source#
 [  �� $��Model:���� -    ��Name$ ModelTextBox���� $��Production year:���� -   $	 ProductionYearComboBox���� $��License Plate:���� -   $ LicensePlateTextBox���� $
��VIN:���� -   $ 
VINTextBox���� $��Engine:���� -   $ EngineTextBox���� $��
Fuel Type:���� -   $	 FuelTypeComboBox������ #
 [ �� $��Gearbox:���� -   $	 GearboxComboBox������ #
 [ �� $��Vehicle class:���� -	   $	 VehicleClassComboBox������ #
 [ �� $��Color:���� -
   $	 ColorComboBox������ #
 [ �� $��Mileage:���� -   $ MileageTextBox���� $��Status:���� -   $	 StatusComboBox������ #
 [ �� $��Price 1-3 days:���� -   $ DailyPrice13TextBox���� $��Price 4-8 days:���� -   $ DailyPrice48TextBox���� $��Price 9-15 days:���� -   $ DailyPrice915TextBox���� $��Price 16-29 days:���� -   $ DailyPrice1629TextBox���� $��Price 30+ days:���� -   $ DailyPrice30PlusTextBox���� $��Weekend price:���� -   $ WeekendPriceTextBox���� $��Deposit:���� -   $ DepositTextBox���� $��Image:���� .+��� -    ��Name$ ImageDropZone��
�������$��1q�$��80�� .  �� Padding$ 5q�._�� .+��� -    ��Name$ PreviewImage��$��Uniform=�$y�	Collapsed=��� -    ��Name$ DropHintText��$+��%Przeciągnij i upuść zdjęcie tutaj��$��Center=�$��Center=�
��������� -   $ ImageInfoText��
��� � �$��12(�$y�	Collapsed=�$%��Zdjęcie załadowane pomyślnie����  �� Orientation$ 
Horizontal=�$��0,10,0,0q�$��Center=�.+��� -   $��Zapisz��$��80���� -   $��Anuluj��$��80��$��10,0,0,0q�