   M S B A M L   `   `   `  ����E  AStickerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:StickerApp
StickerApp  5   	       StickerApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:StickerApp     5   	   -   5        $��myWindow��5   	     � Title$  Stickers��5	   	   $	��938��6   $
��1628��6'    � WindowState$ 	Maximized=�64   .��5      � -   5         �Name$ GridB��5      $
��Auto��6   $��0,0,0,0q�6(   $
��Auto��69   ���	#FFCBD5E4.+�5   
   ]� $
��Auto��6   $
��Auto��6"   $��	0,-22,0,0q�6/   $��2��6B   .+�5      +  %System.Windows.Controls.Ribbon.Ribbon  -   5          Name$ 	RibbonWin��5   *   $	��Top=�6    �� SelectedIndex$ 0��6>   $	��Top=�6P   "   ShowQuickAccessToolBarOnTop .     IsDropDownOpen .  $
��Auto��6�      ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      5  /System.Windows.Controls.Ribbon.RibbonMenuButton   KeyTip$ F��6,   ���	#FF0062FF.@�5      >  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -   5        $��	Open File��5   4   6G     5      -   5        $
��Save��5   4   6B     5      -   5        $��Save As��5   4   6E     5      $
��Exit��64   5      .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $
��Home��6   	   KeyTip$	 H��6*   .@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5        
  Name$

 File��5   "   $
��File��60   .@�5      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5           LargeImageSource$L FC:\Programowanie\Studia\C#\S4 - Programowanie\Stickers\Ribbon\save.png��5   '      Label$
 Save��6�      KeyTip$ Ctrl + S��6�   6�   5        5      -	   5        $
 Action��5   "   $��Action��62   $
��Auto��6B   .@�5        -
   5        $L FC:\Programowanie\Studia\C#\S4 - Programowanie\Stickers\Ribbon\undo.png��5   '   $
 Undo��6�   $ Ctrl + Z��6�   6�     5      -   5        $L FC:\Programowanie\Studia\C#\S4 - Programowanie\Stickers\Ribbon\redo.png��5   '   $
 Redo��6�   $ Ctrl + Y��6�   6�   5         5!      -   5        $
 Tools��5!   "   $��Tools��61   .@�5"      2  ,System.Windows.Controls.Ribbon.RibbonTextBox  -   5          Name$ RotationValue��5"   (    �� 	MaxLength$ 4��6?   $��23��6q    �� TextWrapping$
 Wrap=�6}   $	��360��6�   $��89��6�   $��Center=�6�   $
��Left=�6�   $��1q�6�   $��0,5,0,0q�6�   6  �� 5#      $
��Wrap=�6$   $��Rotation��68   $��23,6,0,0q�6H     5$      -   5        $ 	SizeValue��5$   (   $ 3��6;   $��23��6m   $
 Wrap=�6y   $	��100��6�   $��89��6�   $��Center=�6�   $
��Left=�6�   $��1q�6�   $��0,5,0,0q�6�   6�   �� 5%      $
��Wrap=�6$   $��Sticker Size��68   $��15,6,0,0q�6L   5&        5'      -   5        $

 Zoom��5'   "   $
��Zoom��60   .@�5(        -   5        $P JC:\Programowanie\Studia\C#\S4 - Programowanie\StickerApp\Images\ZoomIn.png��5(   '   $ Zoom On��6�   $ Ctrl + PgUp��6�   6�     5)      -   5        $Q KC:\Programowanie\Studia\C#\S4 - Programowanie\StickerApp\Images\ZoomOut.png��5)   '   $ Zoom Off��6�   $ Ctrl + PgDn��6�   6�   5*      5+      5,      � 5-      $��Right=�6   $��Right=�6*   $
��Auto��6F   .+�5.      �� $
��Auto��6   $	��192��6+   ���	#FFACACAC��67   Z� .@�5/      �� $��Faces��6   .��50      �� .��51      � ���	#FFE5E5E5$
��Auto��6:   $
��Auto��6H    � ColumnDefinitions 52   "   �� 53   &   $	��76* �67   �� 54   &   $	��93* �67   .+�56   "   �� -   5         ��Name$ SmileyFaceButton��56   )   $
��Left=�6C   $��	10,10,0,0q�6^   $	��Top=�6q   $��60��6�   $��60��6�      ButtonStyleSticker#��[  57   %   ��58   &   �� 59   *    �� ImageSource$% Slightly Smiling Face Emoji.png��65   5;   #   �� 5<   "   -   5        $
��Left=�5<   )   $��22.423,10,0,0q�6D   $	��Top=�6[   $��60��6s   $��60��6~   #��[  5=   %   $��1��6Q   ��5>   &   �� 5?   *   $( "Smiling Emoji with Eyes Opened.png��65   5A   #   �� 5B   "   -   5        $
��Left=�5B   )   $��	10,75,0,0q�6D   $	��Top=�6W   $��60��6o   $��60��6z   #��[  5C   %   ��5D   &   �� 5E   *   $) #Smiling Emoji with Smiling Eyes.png��65   5G   #   �� 5H   "   -   5        $
��Left=�5H   )   $��22.423,75,0,0q�6D   $	��Top=�6[   $��60��6s   $��60��6~   #��[  5I   %   $��1��6]   ��5J   &   �� 5K   *   $ Smiling Face Emoji.png��65   5M   #   �� 5N   "   -   5        $
��Left=�5N   )   $��
10,140,0,0q�6D   $	��Top=�6X   $��60��6p   $��60��6{   #��[  5O   %   ��5P   &   �� 5Q   *   $ Tears of Joy Emoji.png��65   5S   #   �� 5T   "   -   5        $
��Left=�5T   )   $��22.423,140,0,0q�6D   $	��Top=�6\   $��60��6t   $��60��6   #��[  5U   %   $��1��6Q   ��5V   &   �� 5W   *   $3 -Tongue Out Emoji with Tightly Closed Eyes.png��65   5Y   #   �� 5Z   "   -   5        $
��Left=�5Z   )   $��
10,205,0,0q�6D   $	��Top=�6X   $��60��6p   $��60��6{   #��[  5[   %   ��5\   &   �� 5]   *   $ Tongue Out Emoji.png��65   5_   #   �� 5`   "   -   5        $
��Left=�5`   )   $��22.423,205,0,0q�6D   $	��Top=�6\   $��60��6t   $��60��6   #��[  5a   %   $��1��6]   ��5b   &   �� 5c   *   $  Upside-Down Face Emoji.png��65   5e   #   �� 5f   "   -   5        $
��Left=�5f   )   $��
10,270,0,0q�6D   $	��Top=�6X   $��60��6p   $��60��6{   #��[  5g   %   ��5h   &   �� 5i   *   $ Very Angry Emoji.png��65   5k   #   �� 5l   "   -   5        $
��Left=�5l   )   $��23.333,270,0,0q�6D   $	��Top=�6\   $��60��6t   $��60��6   #��[  5m   %   $��1��6Q   ��5n   &   �� 5o   *   $ Fearful Face Emoji.png��65   5q   #   �� 5r   "   -   5        $
��Left=�5r   )   $��
10,335,0,0q�6D   $	��Top=�6X   $��60��6p   $��60��6{   #��[  5s   %   ��5t   &   �� 5u   *   $ Astonished Face Emoji.png��65   5w   #   �� 5x   "   -   5        $
��Left=�5x   )   $��23.333,335,0,0q�6D   $	��Top=�6\   $��60��6t   $��60��6   #��[  5y   %   $��1��6]   ��5z   &   �� 5{   *   $ Alien Emoji.png��65   5}   #   5~      5      5�      5�      5�      �� 5�      $
��Left=�6   $
��Auto=�61   $
��auto=�6V   $
��Auto��6y   $
��Auto��6�   .��5�      � -   5        $ GridC��5�      $
��Auto��6&   $
��Auto��64   $
��Left=�6A   $	��Top=�6\   $��3,0,0,0q�6t   .+�5�      	   StickerApp.ZoomBorder	  -   5         	 Name$ border��5�   '   $
��auto��67   $
��auto��6E   $	��Top=�6R   $��2��6j   }�.  	  Child. 5�      �� -    5        $��ImagePanel1��5�       $��ExampleImage.png��63   $
��Auto��6M   $
��Auto��6]    J� RenderTransformOrigin$ 0,0.5&�6j   z�5�      V� 5�   "   .~�5�   &   �� �� 5�   &   �� 5�   &   T� 5�   &   5�   #   5�      5�      �� 5�      -!   5         ��Name$ 
RootCanvas��5�      
������ $��0,0,0,0q�6i    J� IsHitTestVisible . .+�5�      �� -"   5         ��Name$ customPointer��5�   $   ���	#FF8B00FF$��60��6L   $��60��6W    J� Opacity$ 0Q�6c   5�      5�      5�      5�      5�      5�      