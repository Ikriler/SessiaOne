   M S B A M L   `   `   `  ????D  @SessiaOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SessiaOne.ViewsSessiaOne.Views  5      )    #SessiaOne.Views.ControlChampionship   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:SessiaOne.Views     5      .??5	      ?? -   5          ??Name$  BorderWindow??5	       ?? CornerRadius$ 45??6#   
???2?2?$??2q?6M   ._?5
   
   ? .+?5      ?? -   5        $  
BorderGrid??5      $ 45??6)   
???2?2?
???????6h   &   System.Windows.Controls.DataGrid  5      -   5          Name$ gridChampionship??5         AutoGenerateColumns .     SelectionMode$ Single=?6?      CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id??6)      
Visibility$ Hidden=?6Q   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   ?? 
 ?? Path$
 id?6Q     5      $/ )    Название чемпионата??6)   	 6J   ?? $
 title?  5      $ Дата начала??6)   	 6>   ?? $
 
date_start?  5      $# Дата завершения??6)   	 6B   ?? $
 date_end?  5      $ 
Город??6)   	 68   ?? $

 city?  5      $ Описание??6)   	 6;   ?? $
 description? J? OpacityMask 5      !? 5       !? Visual 6"   ??  ?? ElementName$ 
BorderGrid??6N    ? ContextMenu 5      ?? 5      .@?5      m? -   5         m?Name$ seeInfoChampionsip??5   #   $??Подробнее??6`   6u   m? 5      -   5        $ changeChampionship??5   #   $??Изменить??6`   6t   5      5      5      5       5!      