   M S B A M L   `   `   `  ���� E  ACar_Rental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Car_Rental.ViewsCar_Rental.Views  .    (Car_Rental.Views.Edit_Reservation_Window   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     0localclr-namespace:Car_Rental.Views       � Title$  Edit Reservation��$	��700��$	��650�� � 	Resources  �� 
TargetType �� Property �� Value��%�  '��       '�� k     '�� �     '��     �� " ��.���  � ��$ 14(���  � ��$ Right=���  � ��$ Center=���  � ��$ 5q��� " ��.���  � ��$ 14(���  � ��$ 5q���  � ��$ 10q��� " ��.���  � ��$ 14(���  � ��$ 5q���  � ��$ 10q��� " ��.���  � ��$ 14(���  � ��$
 10,5q���  � ��$ 10q���  � ��$ 40��.��� $��0,0,-5,-268q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��0��$��2��$	��Top=�$��20q�.+���  �� Orientation$ 
Horizontal=�$
��0,10q�.+��� $��Reservation ID:��$	��150����  �� 
IsReadOnly . 
�������$	��300������ *ReservationId+�� $ 
Horizontal=�$
��0,10q�.+��� $��Customer Full Name:��$	��150���� $	��300������ *CustomerFullName+�� $ 
Horizontal=�$
��0,10q�.+��� $��Customer PESEL:��$	��150���� $	��300������ *CustomerPESEL+�� $ 
Horizontal=�$
��0,10q�.+��� $
��Car:��$	��150���� -   	 ��Name$	 CarComboBox��
 �� DisplayMemberPath$
 DisplayName�� �� SelectedValuePath$ CarId��$	��300�� �� SelectedValue �� *CarId+�� $ 
Horizontal=�$
��0,10q�.+��� $��Start Date:��$	��150��(  "System.Windows.Controls.DatePicker  $��10,0,0,0q�$	��300��   SelectedDate �� *	StartDate+�� $ 
Horizontal=�$
��0,10q�.+��� $��	End Date:��$	��150��  $��10,0,0,0q�$	��300�� �� *	EndDate+�� $ 
Horizontal=�$
��0,10q�.+��� $��Status Reservation:��$	��150���� -   $	 StatusComboBox��$
 Status��$ Value��$
��Left=�$	��Top=�$	��300��$��10q��� $ 
Horizontal=�$
��0,10q�.+��� $��Total Price:��$	��150���� $	��300������ *
TotalPrice+�� $ 
Horizontal=�$��Center=�$
��0,20q�.+��� -   $
��Save��$	��150��$��10q��� -   $��Cancel��$	��150��$��10q�