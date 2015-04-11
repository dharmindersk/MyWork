V1.0 Scope
1) Find files that are locked out

Usage:

NAME
TFSLockStatus - Helps me

SYNOPSIS
Example : TFSLockStatus /SERVERURL=http://wtfsdg01:8080/tfs /CODEPATH=$/AppDev/TaviscaTemplar/Development/EP5/www.orxenterprise.com/ControlLibrary /SMTPSERVER=smtp.cltsloyalty.com /NOTIFICATIONRECIPIENTS=dharminder@tavisca.com /NOTIFICATIONSENDER=dkhasria@cltsloyalty.com

Switches

/SERVERURL - It specifies path of Server.
/CODEPATH  - TFS path to be searched for locks.
/UNAME - Username - Optional
/PASWD - Password - Optional
/SMTPSERVER - smtp.cltsloyalty.com
/NOTIFICATIONRECIPIENTS=dharminder@tavisca.com 
/NOTIFICATIONSENDER=dkhasria@cltsloyalty.com


DESCRIPTION
This tool finds locked file and send report via emails.

