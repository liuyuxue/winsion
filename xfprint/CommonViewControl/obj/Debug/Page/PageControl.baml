   M S B A M L   `   `   `  ����L  HCommonViewControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CommonViewControlCommonViewControl  5      #    CommonViewControl.PageControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CommonViewControl     5        � 	Resources  5	         PageBtuStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� RenderTransformOrigin �� CornerRadius ��Name	 ��Name
 J� Opacity �� ElementName �� Path �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5
   
   " ��6%   .�5      ��  � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�SnapsToDevicePixels . 64   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $
 root��6!   $ .5,.5&�60   $ 2��6N   ._�5      � .+�5   "   �� $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   �� 5   "   $		 rbg��6,   $
 0Q�69   $��2��6E   ���	#FF194998$��Bottom=�6�   ��6a   �� $ MyContentPresenter��$ ActualWidth�6�   5      5       5      P� 5       � �� . . �5   "   �� $	 rbg��6<    �@J�Opacity$ 1Q�6M   5      5      5      5       5!      .��5"      �� $��Center=�6   $��Center=�6,    �� Orientation$ 
Horizontal=�6I   
�������.+�5#   
   �� -   5        $��firstbtn��5#      $��50��6!   $��30��6,   $��	20,5,20,5q�68   $��Center=�6K   $��首页��6f   #��[  6s   ��5$   %   �� *FirstPageCmd+�� 5%   
   -   5        $��upbtn��5%      $��50��6   $��30��6*   $��0,5,20,5q�66   $��Center=�6I   $��	上一页��6d   #��[  6r   ��5&   %   �� *	UpPageCmd+�� 5'   
   -   5        $��	sp_indexs��5'      $ 
Horizontal=�6&   $��Center=�6?     5(       �� Triggers��%�  '��       �� 5)      " ��6   .�5*      ��  � ��$ 20��6.   �� 5+       � ��$ 12(�61   �� 5,       � ��
 ���� 63   �� 5-       � ��
 �����63   �� 5.       � ��$ 0q�60   �� 5/       � ��
 ���� 64   �� 50       � �� 60   �� *GoToPageCmd+ 52      P� 53       �@J�IsMouseOver . . �54      ��  �@J�Opacity$	 0.7Q�68   55      P� 56       �@J�	IsFocused . . �57      ��  � ��
 �����6;   58      P� 59       �@J�Uid$ 1��61   . �5:      ��  � ��
 �����6;   5;      P� 5<       �@J�Uid$ 0��61   . �5=      ��  � ��
 ���� 6;   5>      5@      5A      5K      �� 5L   
   -   5        $��downbtn��5L      $��50��6"   $��30��6-   $��	20,5,20,5q�69   $��Center=�6L   $��	下一页��6g   #��[  6u   ��5M   %   �� *DownPageCmd+�� 5N   
   -   5        $��endbtn��5N      $��50��6    $��30��6+   $��0,5,20,5q�67   $��Center=�6J   $��末页��6e   #��[  6r   ��5O   %   �� *LastPageCmd+5P      5Q      