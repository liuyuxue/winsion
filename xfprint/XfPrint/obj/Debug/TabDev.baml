   M S B A M L   `   `   `  ����B  >XfPrint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:XfPrintXfPrint  5      L HCommonViewControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:CommonViewControl;assembly=CommonViewControlCommonViewControl 5
          XfPrint.TabDev   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:XfPrint     5      P LPrism.Wpf, Version=6.3.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      Ncommoncontrol:clr-namespace:CommonViewControl;assembly=CommonViewControl  5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  $	��910��5       $
��1600��6-    � 	Resources 5         	dTemplate   XfPrint.UcItem  Name.  (System.Windows.Interactivity.Interaction   Triggers/  )System.Windows.Interactivity.EventTrigger   	EventName.  (System.Windows.Interactivity.TriggerBase   Actions6  0System.Windows.Interactivity.InvokeCommandAction   Command�� 5   
   %�   &	        �� 5      .R�5        $ xx��6    5        5      $ 	MouseDown��6)   . 5         65   �� *ItemClickCommand+5      5      5      5      .��5      � 
������  � RowDefinitions 5   
   �� 5!      $��60 �6   �� 5"      $��* �6   �� 5#      $��50 �6   .+�5&   
   � $��0��6   ���#444445.+�5'      ��  �� Orientation$ 
Horizontal=�6   .+�5(      �� $��甲方单位��6   
�������$��14(�6:   $��Center=�6H   $��	15,2,10,2q�6j   6   �� 5)      $	��300��6   $��30��6'   $��5,2,50,2q�63   $��Center=�6E   	 �� DisplayMemberPath$	 organizationname��5*   B   ��6   �� *Organizations+
 �� SelectedItem
 6g   �� *
OrgCurrent+�� 5+      $��设施分类��6   
�������$��14(�6:   $��Center=�6H   $��	15,2,10,2q�6j   6   �� 5,      -   5        $��cmbDevtypes��5,      $	��250��6.   $��30��6:   $��5,2,15,2q�6F   $��Center=�6X   $	 devicetypename��5-   =    �� SelectedIndex$ -1��6`   ��6   �� *
DevTypes+ 5.        5/      $ SelectionChanged��6)   . 50         65   �� * SelectionDevtypeChangedCommand+   CommandParameter 51   5   �� *SelectedItem+ �� ElementName$ cmbDevtypes��52      54      �� 55      -   5        $��cmbBasedevs��55      $	��250��6.   $��30��6:   $��5,2,2,2q�6F   $��Center=�6W   $	 
devicename��56   >   ��6   �� *	BaseDevs2+
 6^   �� *BaseDevCurrent+�� 57        btn_Text#��[ 6   $��生 成��6<   $��75��6J   $��30��6U   $��30,2,2,2q�6a    58        59      $ Click��6)   . 5:         65   �� *SelectDevDataCommand+5;      5=      �� 5>      #��[ 6   $��打 印��6<   $��75��6J   $��30��6U   $��30,2,2,2q�6a    5?        5@      $ Click��6)   . 5A        $ 	lib1ViewA��6V    65   �� *PrintCommand+6V   5B      5D      �� 5E      $��电话��6   
�������$��14(�68   $��Center=�6F   $��	25,2,10,2q�6h   6}   �� 5F      $	��200��6   $��30��6&   $��Center=�6l   ��62   �� *Tel+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�    5G        5H      $ TextChanged��6)   . 5I         65   �� *TelTextChangedCommand+5J      .��5K   .   5L      5M      5N      � 5O   
   $��1��6   ���#606060.+�5P      �� $ Vertical=�6   .+�5Q      �� $ 
Horizontal=�6   .+�5R      �� $��全选��6   
�������$��25��6<   $	��Top=�6H   $��10,5,5,5q�6`   6t   �� 5S      $	��Top=�6!   $��0,10,5,5q�69    5T        5U      $ 	Unchecked��6-   . 5V   "      69   �� *UnSelectAllItemCommand+5X        5Y      $ Checked��6-   . 5Z   "      69   �� *SelectAllItemCommand+5\      5_      5`      �� 5a      $ 
Horizontal=�6   .+�5b      �� $��数量��6   
�������$��25��6<   $	��Top=�6H   $��10,5,1,5q�6`   6t   �� 5c      
�������$��25��6S   $	��Top=�6_   $��0,5,5,5q�6w   ��6   �� *DevModels.Count+6�   5d      �� 5e      $ 
Horizontal=�6   .+�5f      �� $��选中��6   
�������$��25��6<   $	��Top=�6H   $��10,5,1,5q�6`   6t   �� 5g      
�������$��25��6S   $	��Top=�6_   $��0,5,5,5q�6w   ��6   �� *SelectItemCount+6�   5h      5i      �� 5j      -   5        $��listview��5j      
������ $��5,3,5,3q�6@   $��Hidden=�6R   $
��1230��5k      $��Disabled=�6$   $��Center=�6Z   $��0q�5l      #��[  6+   ��6U   �� *	DevModels+��5m      �� 5n      .R�5o      � 6&   5p      5r      5s      � 5t   
   $��2��6   ���#444445.+�5u      #  CommonViewControl.PageControl     CurrentIndex 6)   �� *CurrentPageIndex+   
TotalPages 5v      �� *	PageCount+6?   5w      5x      5y      