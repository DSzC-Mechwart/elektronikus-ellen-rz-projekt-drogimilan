   M S B A M L   `   `   `  ����  	Tantárgy    TantargyApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Tantárgy Felvitel��5   	   $	��350��6#   $	��400��60   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Tantárgy neve:��6   $��Center=�66   �� 5   
   -   5         ��Name$ tantargyNevTextBox��5      $��0��6.   $��	120,0,0,0q�6;   �� 5   
   $��1��6   $��Évfolyam (9-13):��6   $��Center=�68   �� 5   
   -   5        $ evfolyamTextBox��5      $��1��6+   $��	120,0,0,0q�68   �� 5   
   $��2��6   $��Tantárgy típusa:��6   $��Center=�68   �� 5   
   -   5         ��Name$ tantargyTipusComboBox��5      $��2��62   $��	120,0,0,0q�6?   .@�5      �� $��közismereti��6    �� 
IsSelected$
 True��61   �� 5      $��szakmai��6   5      �� 5   
   $��3��6   $��Heti óraszám:��6   $��Center=�65   �� 5   
   -   5        $ hetiOraszamTextBox��5      $��3��6.   $��	120,0,0,0q�6;   �� 5   
   -   5        $��4��5      $��Mentés��6   $��Center=�6D   $
��0,10q�6a   �� 5    
   -   5         ��Name$ messageTextBlock��5       $��5��6.   
��� � � �� TextAlignment$ Center=�6N   5!      5"      