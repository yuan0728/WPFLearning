   M S B A M L   `   `   `  ����M  IXH.AnimationLesson, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:XH.AnimationLesson.DemoXH.AnimationLesson.Demo  5   	   *    $XH.AnimationLesson.Demo.DrawerWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:XH.AnimationLesson.Demo     5   	     � Title$  DrawerWindow��5   	   $	��450��6   $	��800��6+    � 	Resources 5
      ��%    5       � Triggers 5      :� 5   
    :� RoutedEvent$ Button.Click��6    :� 
SourceName$ btn_1��62   .[�5      �� .��5      �� .��5      t�  g� Duration$ 0:0:0.5D�6)   	 t� To 06<    �� 
TargetName$ border��6C    �� TargetProperty$ Margin�6b   5      5      5      :� 5   
   $ Button.Click��6   $ btn_2��62   .[�5      �� .��5      �� .��5      t� $ 0:0:0.5D�6)    
-180 0 0 06<   $ border��6L   $ Margin�6k   5      5      5      .��5       � .+�5!   
   �� -   5        $��btn_1��5!      $��30��6   $��30��6)   $	��Top=�65   $
��Left=�6M   �� 5"   
   -   5        $��border��5"   ^   $	��180��6   ���#DDD$
��Left=�6/   $��
-180 0 0 0q�6J   ._�5#      �� -   5        $��btn_2��5#   `   $��30��6   $��30��6    $	��Top=�6,   $��Right=�6D   6`   5$      5%      5&      