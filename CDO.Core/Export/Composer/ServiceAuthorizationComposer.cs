using CDO.Core.ErrorHandling;
using CDO.Core.Export.Templates;
using CDO.Core.Models;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;

namespace CDO.Core.Export.Composer;

public sealed class ServiceAuthorizationComposer(ServiceAuthorization sa) {
    private readonly ServiceAuthorization _sa = sa;
    private readonly ITemplateProvider _templateProvider = new TemplateProvider();

    public Task<Result<string>> Compose() {
        var tcs = new TaskCompletionSource<Result<string>>();

        if (_templateProvider.GetTemplate("Invoice.dotx") is not string path) {
            tcs.SetResult(Result<string>.Fail(new AppError(ErrorKind.Unknown, "Invoice Template not found.")));
            return tcs.Task;
        }


        var thread = new System.Threading.Thread(() => {
            try {
                var wordService = new WordInteropService();
                wordService.ExportServiceAuthorization(path, _sa);

                tcs.SetResult(Result<string>.Success("success"));
            } catch (Exception ex) {
                tcs.SetResult(Result<string>.Fail(new AppError(ErrorKind.Unknown, "Failed to export Service Authorization", Exception: ex)));
            }
        });

        thread.SetApartmentState(ApartmentState.STA); // MUST do before Start
        thread.Start();

        return tcs.Task;
    }
}

public sealed class WordInteropService {
    public void ExportServiceAuthorization(string templatePath, ServiceAuthorization sa) {
        Debug.WriteLine(templatePath);
        var app = new Word.Application();

        var doc = app.Documents.Open(templatePath);

        try {
            foreach (Word.FormField field in doc.FormFields) {
                switch (field.Name) {
                    case "ID":
                        field.Result = sa.Id;
                        break;
                    case "DRSOffice":
                        field.Result = sa.Office ?? "";
                        break;
                    case "ClientName":
                        field.Result = sa.Client?.Name ?? "";
                        break;
                    case "CaseID":
                        field.Result = sa.Client?.CaseID ?? "";
                        break;
                    case "StartDate":
                        field.Result = sa.StartDate.ToString(format: "MM/dd/yyyy") ?? "";
                        break;
                    case "EndDate":
                        field.Result = sa.EndDate.ToString(format: "MM/dd/yyyy") ?? "";
                        break;
                    case "SecretaryName":
                        field.Result = sa.Client?.CounselorReference?.SecretaryName ?? "";
                        break;
                    case "CounselorName":
                        field.Result = sa.Client?.CounselorReference?.Name ?? "";
                        break;
                    case "UM":
                        field.Result = sa.UnitOfMeasurement ?? "";
                        break;
                    case "SADescription":
                        field.Result = sa.Description;
                        break;
                    case "UnitCost":
                        field.Result = sa.UnitCost?.ToString("C2") ?? "";
                        break;
                    case "TotalLineCost":
                        field.Result = sa.UnitCost?.ToString("C2") ?? "";
                        break;
                    case "GrandTotal":
                        field.Result = sa.UnitCost?.ToString("C2") ?? "";
                        break;
                }
            }
        } catch (Exception ex) {
            Debug.WriteLine(ex.ToString());
        }
    }
}
