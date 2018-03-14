<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_Intermediate_Shift.aspx.cs" Inherits="Add__Intermediate_Shift" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>משמרון - הכנסת משמרת ביניים</title>
    <style type="text/css">
        #Select1
        {
            width: 117px;
        }
    </style>
</head>
<body style="text-align: right" >
<script type="text/javascript" language="javascript">
   function CheckAdmin() {
   
        if (document.AIS.SM1.value.length != 2) {
            document.AIS.SM1.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
                if (document.AIS.SM1.value>24) {
            document.AIS.SM1.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (CheckNumbers(document.AIS.SM1.value) == false) {
            document.AIS.SM1.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }

        if (document.AIS.SM2.value.length != 2) {
            document.AIS.SM2.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
                if (document.AIS.SM2.value>59) {
            document.AIS.SM2.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (CheckNumbers(document.AIS.SM2.value) == false) {
            document.AIS.SM2.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.AIS.EM1.value.length != 2) {
            document.AIS.EM1.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
                if (document.AIS.EM1.value>24) {
            document.AIS.EM1.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (CheckNumbers(document.AIS.EM1.value) == false) {
            document.AIS.EM1.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        if (document.AIS.EM2.value.length != 2) {
            document.AIS.EM2.focus();
            alert("נא הכנס מספר דו-ספרתי");
            return false;
        }
                if (document.AIS.EM2.value>59) {
            document.AIS.EM2.focus();
            alert("נא הכנס שעה חוקית");
            return false;
        }
        if (CheckNumbers(document.AIS.EM2.value) == false) {
            document.AIS.EM2.focus();
            alert("נא השתמש במספרים בלבד");
            return false;
        }
        
         return true;
        }
           function CheckWorker() {
          if (document.AIS.shift ==null) {
            alert("נא בחר משמרת");
            return false;
        }
        return true;
         
    }
            function CheckNumbers(Text) {
        var Let = "1234567890";
        var tav, i;
        for (i = 0; i < Text.length; i++) {
            tav = Text.charAt(i);
            if (Let.indexOf(tav) == -1)
                return false;
        }
        return true;
    }

    
       function remove(myStr, ind, len) {
      first= myStr.substr(0, ind);
      last = myStr.substr(ind+len, myStr.length-(ind+len));
      var st= first+last;
       var day = parseInt(document.AIS.Day.value);
        switch( day )
        {
          case 1:
               opener.document.Shifts.Sunday_intermediate.value=st;
               break;
          case 2:
               opener.document.Shifts.Monday_intermediate.value=st;
               break;
                         case 3:
               opener.document.Shifts.Tuesday_intermediate.value=st;
               break;
                         case 4:
               opener.document.Shifts.Wednesday_intermediate.value=st;
               break;
                         case 5:
               opener.document.Shifts.Thursday_intermediate.value=st;
               break;
                         case 6:
               opener.document.Shifts.Friday_intermediate.value=st;
               break;
                         case 7:
               opener.document.Shifts.Saturday_intermediate.value=st;
               break;
        }
        
        self.close();
        return true;
    }
    function INSAdmin(st) {
        if (CheckAdmin) {
            for (i = (13 - st.length); i > 0; i--) {
                st += " ";
            }
            st += document.AIS.SM1.value + ":" + document.AIS.SM2.value + "-" + document.AIS.EM1.value + ":" + document.AIS.EM2.value;
            st += "  ";
            INSShift(st)
        }
         }
         
      function INSWorker(st) {
          if (CheckWorker) {
              for (i = (13 - st.length); i > 0; i--) {
                  st += " ";
              }
              for (i = 0; i < document.AIS.shift.length; i++)
                  if (document.AIS.shift[i].checked)
                  st += document.AIS.shift[i].value;
              st += "  ";
              INSShift(st)
          }
         }
         function INSShift(st)
         {
        var day = parseInt(document.AIS.Day.value);
        switch( day )
        {
          case 1:
               opener.document.Shifts.Sunday_intermediate.value+=st;
               break;
          case 2:
               opener.document.Shifts.Monday_intermediate.value+=st;
               break;
                         case 3:
               opener.document.Shifts.Tuesday_intermediate.value+=st;
               break;
                         case 4:
               opener.document.Shifts.Wednesday_intermediate.value+=st;
               break;
                         case 5:
               opener.document.Shifts.Thursday_intermediate.value+=st;
               break;
                         case 6:
               opener.document.Shifts.Friday_intermediate.value+=st;
               break;
                         case 7:
               opener.document.Shifts.Saturday_intermediate.value+=st;
               break;
        }
        self.close();
    }
    
    </script>
<form name="AIS" action="">
<input id="hidden1" type="hidden" name="Day"  value="<%=day%>"/>
<input id="hidden2" type="hidden" name="IN" value="<%=txt%>" />

<%if (bool.Parse(Session["Admin"].ToString()))
  { %>
        <table dir="ltr" align="center" >
            
        <tr>
        <td colspan="2">
        <%Response.Write("<font color='blue'>" + "באילו שעות ברצונך להכניס את " + name + " ביום " + name_of_day(day) + "</font>"); %>
        </td>
        </tr>
        <tr><td colspan="2" style="border-width: medium; border-style: dotted">
        <%Print_admin_view(); %>
        </td></tr>
        <tr>

            <td>
                <input id="Text1" name="SM1" style="width: 20px;" type="text"
                     maxlength="2"/>
                :
                <input id="Text5" name="SM2" style="width: 20px;" type="text" 
                     maxlength="2"/>
                
                </td>
                            <td>
                התחלה</td>
        </tr>
        <tr>
            
                        <td>
                <input id="Text2" name="EM1" style="width: 20px;" type="text"  
                     maxlength="2"/>
                :
                <input id="Text6" name="EM2" style="width: 20px;" type="text" 
                     maxlength="2"/>
                
                </td>
                <td>
                סיום</td>
        </tr>
        <tr>
        

<script type="text/javascript" language="javascript">
var ind=document.AIS.IN.value.indexOf("<%=name%>");
if (ind != -1)
    document.write("<td><input type='button' name='submit3' value='הסר את עצמך' onclick='remove(document.AIS.IN.value,ind,26)' /></td>");


                </script>
                <td >
                        <input type="button" name="submit" value="הוסף" onclick="INSAdmin('<%=name %>')" />
                </td>
        </tr>

       
        
    </table>
    <%}
  else { Print_worker_view(); } %>
    
<input id="Radio1" name="shift" type="radio" 
    
    style="border-style: none; background-color: #FFFFFF; height: 0px; width: 0px;" 
    disabled="disabled" size="20" />
    </form>
</body>
</html>
