window.downloadPDF = async () => {
    console.log('downloadPDF function called');
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    const element = document.querySelector('.payslip-container');
    doc.save('payslip.pdf');
};