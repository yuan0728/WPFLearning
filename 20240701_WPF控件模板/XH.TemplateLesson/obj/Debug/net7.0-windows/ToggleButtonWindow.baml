   M S B A M L   `   `   `  ����L  HXH.TemplateLesson, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:XH.TemplateLessonXH.TemplateLesson  5   	   *    $XH.TemplateLesson.ToggleButtonWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:XH.TemplateLesson     5   	   $��30(�5        � WindowStartupLocation$  CenterScreen=�6(    � Title$ ToggleButtonWindow��5   	   $	��450��6$   $	��800��61    � 	Resources 5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ToggleButtonStyle �� 
TargetType	 �� 
TargetType
 ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName  FocusVisual1  Button.Static.Background1  Button.Static.Border1   Button.MouseOver.Background1  Button.MouseOver.Border1  Button.Pressed.Background1  Button.Pressed.Border1  Button.Disabled.Background1  Button.Disabled.Border1  Button.Disabled.Foreground1  ToggleButtonStyleDemo �� CornerRadius A�Name��%  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 &	 �    &	 �    &	 �    &	 �    &	     &	 /    &	 R    &	 u    &	 �    &	 �    &	 �    7  7  7  �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " d�6*   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      "	 d�6&   .R�5(      �� $
 border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   ._�5)      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted$
 true��6D   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      �� 5D   
   .�5E      ��  � �� 5F      �� 5G      .R�5H      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5I      5K      5L      �� 5M   
   $ 	#FFDDDDDD��6<   �� 5N   
   $ 	#FF707070��68   �� 5O   
   $ 	#FFBEE6FD��6?   �� 5P   
   $ 	#FF3C7FB1��6;   �� 5Q   
   $ 	#FFC4E5F6��6=   �� 5R   
   $ 	#FF2C628B��69   �� 5S   
   $ 	#FFF4F4F4��6>   �� 5T   
   $ 	#FFADB2B5��6:   �� 5U   
   $ 	#FF838383��6>   �� 5V   
   " d�6.   .�5W      ��  �@�FocusVisualStyle8   61   �� 5X       � ��8  6+   �� 5Y       � ��8  6,   �� 5Z       � ��# � ��6+   �� 5[       � ��$ 1q�60   �� 5\       � ��$ Center=�6;   �� 5]       � ��$ Center=�69   �� 5^       � ��$ 1q�6(   �� 5_       � �� 5`      �� 5a      "	 d�6&   .R�5b      �� $
 border��6!   $��2q�61   $ 5��6E   #��z��6V   #��z��6�   ._�5c      � .+�5d   "   A� $ ellipse��6*   
������ $��2q�6N   �� 5e   "   $ contentPresenter��63   $��Center=�6M   $��Center=�6j   $
��True��6�   5f      5g       5h      P� 5i       �@d�	IsChecked$
 TrueY�6;   . �5j   "   �� $ border��6)    � ��
 ��ح�6S   �� 5k   "   $ ellipse��6)    � ��
 ��  �6N   5l      P� 5m       � {�$ False��6;   . �5n   "   �� $ border��6)    � ��
 �����6S   �� 5o   "   $ ellipse��6)    � ��
 �����6N   �� 5p   "    � ��
 �����6?   5q      5s      5u      5v      5w      .��5x      � .+�5y   
   d� #��� 
 6    d� 	IsChecked$
 TrueY�5z      $y�	Collapsed=�5{      $��Hello ToggleButton��5|      $��Center=�5}      $��Center=�5~      d� 5�   
   #���  6   $��Hello ToggleButton��5�      $��Center=�5�      $��Center=�5�       5�      Z� 5�      5�      5�      