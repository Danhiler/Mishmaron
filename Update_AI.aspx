<%@ Page Title="עדכון צורך שבועי בעובדים" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="Update_AI.aspx.cs" Inherits="Update_AI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<script type="text/javascript">
    function check() {
        if (document.getElementsByName("H_0_0_0")[0] == null) return true;//no intermediate shifts
        for (i = 0; i < 4; i++) 
           {
        var j=0;
        while (document.getElementsByName("H_" + i + "_" + j + "_0")[0] != null)
              {
                  for (w = 0; w < 4; w++) 
                  if(document.getElementsByName("H_" + i + "_" + j + "_" + w)[0].value!=""){
                      if (!CheckIsNumber(document.getElementsByName("H_" + i + "_" + j + "_" + w)[0].value)) {
                          alert("שעות ביניים חייבות להכיל מספרים בלבד");
                          return false;
                      }
                      switch (w) {
                          case 1:
                          case 3:
                          if(parseInt(document.getElementsByName("H_" + i + "_" + j + "_" + w)[0].value)>24||parseInt(document.getElementsByName("H_" + i + "_" + j + "_" + w)[0].value)<0)
                          {
                              alert("שעה אינה חוקית");
                              document.getElementsByName("H_" + i + "_" + j + "_" + w)[0].focus()
                          return false;
                          }
                              break;
                          case 0:
                          case 2:
                          if(parseInt(document.getElementsByName("H_" + i + "_" + j + "_" + w)[0].value)>59||parseInt(document.getElementsByName("H_" + i + "_" + j + "_" + w)[0].value)<0)
                          {
                              alert("שעה אינה חוקית");
                              document.getElementsByName("H_" + i + "_" + j + "_" + w)[0].focus()
                          return false;
                          }
                              break;
                          default:
                              return false;
                              break;
                      }
                  }
                j++;
              }
        
           }
        }
        function CheckIsNumber(Text) {
            var Let = "1234567890";
            var tav, i;
            for (i = 0; i < Text.length; i++) {
                tav = Text.charAt(i);
                if (Let.indexOf(tav) == -1)
                    return false;
            }
            return true;
        }
</script>
<form name="AI_Options" method="post" action="Updated_AI.aspx" onsubmit="return check();" >
<input type="hidden" name="kind" value="1" /><!--start of the week-->
    
  <h2><b> קביעת צורך שבועי בעובדים - אמצע שבוע</b></h2>

    <table style="width: 500px;" class="sample" align="center">
        <tr>
            <td style="border-top-style: none; border-right-style: none">
               <img src="Pictures\right_arrow_dis.png" width="30" border="0" alt="תחילת שבוע" />
               </td>
            <th align="center">
                ראשון</th>
            <th align="center">
                שני</th>
            <th align="center">
                שלישי</th>
            <th align="center">
                רבעי
                
                </th>
               
            <td align="center" width="30" style="border-top-style: none; border-left-style: none">
                <a href="Update_AI_2.aspx">
                <img alt="סוף שבוע" border="0" src="Pictures\left_arrow.png" width="30" /></a></td>
               
        </tr>
        
       <tr>
            <td>
                בוקר</td>
                <%print_Morning(); %>     
        </tr>
        <%if (use_intermediate)
          { %>
   <tr><td>
   ביניים
   </td>
            <% print_Intermediate(); %>
   </tr>
   <%} %>
        <tr>
            <td>
                ערב</td>
               <%print_Evening(); %>
        </tr>
       
            </table>
            <input id="m_button" type="submit" value="שמור" />

   </form>
</asp:Content>

