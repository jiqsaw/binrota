function OpenForgotPassword() {
    var OpenPen = window.open("ForgotPassword.aspx", 'BinrotaSifreHatirlat', 'width=390,height=235,toolbar=no');
    OpenPen.focus();
}

function OpenRegisterForm() {
    var OpenPen = window.open("MemberWarning.aspx", 'BinrotaYeniUye', 'width=461,height=573,toolbar=no');
    OpenPen.focus();
}

function OpenHowToBeAMember() {
    var OpenPen = window.open("HowToBeAMember.aspx", 'BinrotaYeniUye', 'width=461,height=573,toolbar=no');
    OpenPen.focus();
}

function OpenAddComment(PageID) {
    var OpenPen = window.open("AddComment.aspx?PageID=" + PageID, 'BinrotaYorumEkle', 'width=461,height=343,toolbar=no');
    OpenPen.focus();
}

function OpenAddComplain(PageID) {
    var OpenPen = window.open("AddComplain.aspx?PageID=" + PageID, 'BinrotaSikayetEkle', 'width=461,height=343,toolbar=no');
    OpenPen.focus();
}

function OpenAddPages(PageID) {
	if (PageID==null) {
		PageID = 0;
	}
    window.open("AddPage.aspx?PageID=" + PageID, 'BinrotaSayfaEkleme', 'width=1000,height=800,toolbar=no,resizable=yes,scrollbars=yes,');
}

function OpenAddPagesBySubjectID(SubjectID) {
    window.open("AddPage.aspx?SubjectID=" + SubjectID, 'BinrotaSayfaEkleme', 'width=1000,height=800,toolbar=no,resizable=yes,scrollbars=yes,');
}

function Zoom(FileName) {
    var WPen = window.open('Zoom.aspx?Image=' + FileName, 'TurquiaImages', 'toolbar=no, scrollbars, resizable');
    WPen.focus();
    return;
}

function OpenSinglePhotoView(PhotoPath) {
    window.open("SinglePhotoView.aspx?PhotoPath=" + PhotoPath, 'BinrotaPhotoPath', 'width=250,height=250,toolbar=no,resizable=yes, status=no');
}