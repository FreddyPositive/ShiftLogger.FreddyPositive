
import { ShiftLoggerComponent } from "./Components/ShiftLoggerComponent.js";
import { ApiService } from "./API/APIService.js";

const apiService = new ApiService("https://localhost:7210/api/ShiftLogger/");

$(document).ready(() => {

    EmployeeDropDown();

    ShiftLogTable();

    $(document).on("click", "#sl-shift-in", async function () {
        const employeeId = $("#EmployeeListDdl").data("selected-empid");

        var isValidEmployeeId = ValidEmployeeId(employeeId);
        if (isValidEmployeeId) {
            $('#sl-shift-in').prop('disabled', true);
            $('#sl-shift-out').prop('disabled', false);
            const shiftLogger = new ShiftLoggerComponent(apiService);
            await shiftLogger.ShiftIn(employeeId);
            ShiftLogTable();
        }
    });

    $(document).on("click", "#sl-shift-out", async function () {
        const employeeId = $("#EmployeeListDdl").data("selected-empid");

        var isValidEmployeeId = ValidEmployeeId(employeeId);
        if (isValidEmployeeId) {
            $('#sl-shift-in').prop('disabled', false);
            $('#sl-shift-out').prop('disabled', true);
            const shiftLogger = new ShiftLoggerComponent(apiService);
            await shiftLogger.ShiftOut(employeeId);
            ShiftLogTable();
        }

    });

    $(document).on("click", "#EmployeeListDdl ul li", function () {
        const empId = $(this).data("empid");
        const empName = $(this).text();

        $("#EmployeeListDdl button").text(empName);

        $("#EmployeeListDdl").data("selected-empid", empId);

        GetEmployeeShiftStatus(empId);
    });

});

async function EmployeeDropDown() {

    const shiftLogger = new ShiftLoggerComponent(apiService);
    const employeeList = await shiftLogger.GetEmployees();
    RenderEmployeeTable(employeeList)
}

function RenderEmployeeTable(employeeList) {
    const employeeDropdownOption = $("#EmployeeListDdl ul");
    employeeDropdownOption.empty();
    employeeList.forEach(emp => {
        employeeDropdownOption.append(
            `
        <li data-empid="${emp.id}"class="dropdown-item">${emp.name}</li>
        `
        )
    });
}
async function ShiftLogTable() {
    const shiftLogger = new ShiftLoggerComponent(apiService);
    const shiftLog = await shiftLogger.GetShiftLog();
    RenderShiftLogTable(shiftLog)
}

async function GetEmployeeShiftStatus(empId) {
    const shiftLogger = new ShiftLoggerComponent(apiService);
    var isEmployeeShiftActive = await shiftLogger.GetEmployeeShiftStatus(empId)
    if (isEmployeeShiftActive == true) {
        $('#sl-shift-out').prop('disabled', false);
        $('#sl-shift-in').prop('disabled', true);
    }
    else {
        $('#sl-shift-out').prop('disabled', true);
        $('#sl-shift-in').prop('disabled', false);
    }
}

function RenderShiftLogTable(shiftLog) {
    const shiftLogTable = $(".sl-shiftlog-table tBody");
    shiftLogTable.empty();
    var RowNo = 1;
    shiftLog.forEach(log => {
        shiftLogTable.append(
            `
            <tr>
             <td>${RowNo++}</td>
              <td>${log.name}</td>
              <td>${formatShiftStatus(log.shiftStatus)}</td>
              <td>${formatHours(log.totalWorkingHours)}</td>
            </tr>
            `
        )
    });
}
function formatShiftStatus(shiftStatus) {
    return (shiftStatus == 1) ? "Active" : "In-Active"
}
function formatHours(totalWorkingHours) {
    if (totalWorkingHours == null || isNaN(totalWorkingHours)) return "-";

    const totalMinutes = Math.round(totalWorkingHours * 60);
    const hours = Math.floor(totalMinutes / 60);
    const minutes = totalMinutes % 60;

    if (hours === 0) return `${minutes} min`;
    if (minutes === 0) return `${hours} hr`;
    return `${hours} hr ${minutes} min`;
}

function ValidEmployeeId(employeeId) {
    if (employeeId == 0 || employeeId == "" || employeeId == null || employeeId == undefined) {
        Swal.fire({
            title: "Error!",
            text: "Please Choose a Employee to proceed",
            icon: "error",
            confirmButtonText: "OK"
        });
        return false;
    }
    return true;
}