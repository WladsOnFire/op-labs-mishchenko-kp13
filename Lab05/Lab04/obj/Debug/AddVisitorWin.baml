   M S B A M L   `   `   `  ����@  <Lab04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab04Lab04  5   	       Lab04.AddVisitorWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab04     5   	     � Title$  AddVisitorWin��5   	   $	��450��6   $	��800��6,    � 
ResizeMode$ CanMinimize=�68   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��
VisitorsDG��5
      $��383,48,26,17q�6%      
IsReadOnly . 6M   �� 5   
   $��Select existing visitor��6   $
��Left=�62   $��
421,17,0,0q�6M   $	��Top=�6a   $��16(�6y   �� 5   
   -   5        $��	SurnameTb��5      $
��Left=�6#   $��
129,70,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��217��6�   6�   �� 5   
   -   5         ��Name$ FirstNameTb��5      $
��Left=�6'   $��129,109,0,0q�6B   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��217��6�   6�   �� 5   
   -   5        $ SecondNameTb��5      $
��Left=�6(   $��129,146,0,0q�6C   $
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $	��217��6�   6�   �� 5   
   -   5        $ EmailTb��5      $
��Left=�6#   $��129,180,0,0q�6>   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��217��6�   6�   �� 5   
   -   5        $ PhoneNumberTb��5      $
��Left=�6)   $��129,212,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��217��6�   6�   �� 5   
   -   5        $ 	CountryTb��5      $
��Left=�6%   $��129,249,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��217��6�   6�   �� 5   
   $��Surname��6   $
��Left=�6"   $��	37,66,0,0q�6=   $	��Top=�6P   �� 5   
   $��
First name��6   $
��Left=�6%   $��
37,105,0,0q�6@   $	��Top=�6T   �� 5   
   $��Second name��6   $
��Left=�6&   $��
37,142,0,0q�6A   $	��Top=�6U   �� 5   
   $��Email��6   $
��Left=�6    $��
37,176,0,0q�6;   $	��Top=�6O   �� 5   
   $��Phone number��6   $
��Left=�6'   $��
37,208,0,0q�6B   $	��Top=�6V   �� 5   
   $��Country��6   $
��Left=�6"   $��
37,240,0,0q�6=   $	��Top=�6Q   �� 5   
   $��Visitor��6   $
��Left=�6"   $��
104,17,0,0q�6=   $	��Top=�6Q   $��16(�6i   �� 5   
   -   5        $��AddBt��5   '   $��Add visitor��6   {�.  $
��Left=�6H   $��
10,366,0,0q�6c   $	��Top=�6w   $��31��6�   $	��168��6�   6�   �� 5   
   -	   5        $��CancelBt��5   ,   $��Cancel selection��6   {�.  $
��Left=�6O   $��194,366,0,0q�6j   $	��Top=�6   $��31��6�   $	��168��6�   6�   �� 5   
   -
   5        $��
FeedbackTb��5      $
��Left=�6&   $��
94,288,0,0q�6A   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��252��6�   $��61��6�   �� 5   
   $��Feedback��6   $
��Left=�6#   $��
17,288,0,0q�6>   $	��Top=�6R   5      5      