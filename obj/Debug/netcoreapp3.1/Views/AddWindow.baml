   M S B A M L   `   `   `  ����G  CFolderSyncer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FolderSyncerFolderSyncer  5   	   A%clr-namespace:FolderSyncer.ModelViewsFolderSyncer.ModelViews  5   	       FolderSyncer.AddWindows   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FolderSyncer     5   	   <
modelviews%clr-namespace:FolderSyncer.ModelViews     5   	   D @ModernWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.3.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5
   	   -   5          �Name$  	AddWindow��5	   Y    � Title$ 	AddWindow��6	   $	��300��6   $	��400��6(    � WindowStartupLocation$ CenterScreen=�64   0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle$
 True��5   	    � DataContext 5      0  *FolderSyncer.ModelViews.AddFolderViewModel  5   
   -   5        vm��5   (   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      $��40 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $	��300 �6   �� 5      $��30 �6   �� 5      .+�5   
   �� -   5         ��Name$ FirstFolderAdd��5      $��2��6)   $��1��69   
������ ��6_   ��  �� Path$ FirstFolderSelect�.��5      �� $/��)/FolderSyncer;component/Views/3Points.png��6   $��Bottom=�6G   $��30��6b   5      �� 5    
   -   5        $ SecondFolderAdd��5       $��2��6*   $��3��6:   
������ ��5!      �� $ SecondFolderSelect�.��5"      �� $/��)/FolderSyncer;component/Views/3Points.png��6   $��Bottom=�6G   $��30��6b   5#      �� 5$   
   -   5        $��FirstFolder��5$      $��Center=�6%   $��1��6@   $��1��6P   $��30��6]   $��16(�5%   2   ��6   �� $ 	FirstPath�.��6@   	 � ToolTip	 5&      �� 5'      $��Source Folder��6   .��5(      5)      �� 5*   
   -   5        $��SecondFolder��5*      $��Center=�6&   $��1��6A   $��3��6Q   $��30��6^   $��16(�5+   3   ��6   �� $ 
SecondPath�.��6A   	 5,      �� 5-      $��Destination Folder��6   .��5.      5/      �� 51   
   -   5        $
 Done��51      $
��Done��6   $��Center=�52      $��Stretch=�6,   $��1��6J   $��4��6Z   $��2��6g   $��30��6{   ��51   .   �� $
 Done�52   {   53      55      