Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Text
Imports DevExpress.Web.ASPxClasses.Internal

Partial Public Class CssHandler
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Response.Clear()

        ' CSS
        If Not Request.QueryString("cssfolder") Is Nothing Then
            Response.ContentType = "text/css"

            Dim path As String = GetPhysicalPath(Request.QueryString("cssfolder"))
            Dim files As String() = Directory.GetFiles(path, "*.css")
            WriteFilesToResponse(files)
            Response.AddFileDependency(path)
        ElseIf Not Request.QueryString("cssfile") Is Nothing Then
            Response.ContentType = "text/css"

            Dim fileName As String = GetPhysicalPath(Request.QueryString("cssfile"))
            If (Path.GetExtension(fileName).ToLowerInvariant() <> ".css") Then
                Return
            End If
            WriteFilesToResponse(New String() {fileName})
        Else ' JS
            If Not Request.QueryString("jsfolder") Is Nothing Then
                Response.ContentType = "text/javascript"

                Dim path As String = GetPhysicalPath(Request.QueryString("jsfolder"))
                Dim files As String() = Directory.GetFiles(path, "*.js")
                WriteFilesToResponse(files)
                Response.AddFileDependency(path)
            ElseIf Not Request.QueryString("jsfile") Is Nothing Then
                Response.ContentType = "text/javascript"

                Dim fileName As String = GetPhysicalPath(Request.QueryString("jsfile"))
                If (Path.GetExtension(fileName).ToLowerInvariant() <> ".js") Then
                    Return
                End If
                WriteFilesToResponse(New String() {fileName})
            End If
        End If

        SetCaching()

        'The following line can be removed if the DXEnableHtmlCompression option within Web.config is enabled
        DevExpress.Web.ASPxClasses.ASPxWebControl.MakeResponseCompressed()
    End Sub

    Protected Function GetPhysicalPath(ByVal path As String) As String
        If (Not UrlUtils.IsAppRelativePath(path)) Then
            path = "~/" & path
        End If
        Return Server.MapPath(path)
    End Function
    Protected Sub SetCaching()
        Response.Cache.VaryByParams("cssfolder") = True
        Response.Cache.VaryByParams("cssfile") = True
        Response.Cache.VaryByParams("jsfolder") = True
        Response.Cache.VaryByParams("jsfile") = True

        Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate)
        Response.Cache.SetOmitVaryStar(True)
        Response.Cache.SetLastModifiedFromFileDependencies()
    End Sub
    Protected Sub WriteFilesToResponse(ByVal files As String())
        For Each fileName As String In files
            Dim text As String = File.ReadAllText(fileName)
            Response.Write(text)
            Response.AddFileDependency(fileName)
        Next fileName
    End Sub
End Class