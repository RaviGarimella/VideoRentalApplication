try {
    $(document).ready(function () {
        $('#btnAdd').on("click", saveIssue(event))
    });
    function saveIssue(e) {
        var issueDescription = $("#txtdesc").val();
        var issueSeverity = $("#ddlseverity").val();
        var issueAssigned = $("#txtassigned").val();
        var issueID = chance.guid();
        var issueStatus = "Open";
        var issue = {
            id: issueID,
            description: issueDescription,
            severity: issueSeverity,
            assigned: issueAssigned,
            status: issueStatus
        }
        if (localStorage.getItem('issues') == null) {
            var issues = [];
            issues.push(issue);
            localStorage.setItem('issues', JSON.stringify(issues));
        } else {
            var issues = JSON.parse(localStorage.getItem('issues'));
            issues.push(issue);
            localStorage.setItem('issues', JSON.stringify(issues));
        }
        //$('issueForm').reset();

        fetchIssues();

        e.preventDefault();
    }

    function setStatusClosed(id) {
        var issues = JSON.parse(localStorage.getItem('issues'));

        for (var i = 0; i < issues.length; i++) {
            if (issues[i].id == id) {
                issues[i].status = "Closed";
            }
        }
        localStorage.setItem('issues', JSON.stringify(issues));
        fetchIssues();
    }

    function deleteIssue(id) {
        var issues = JSON.parse(localStorage.getItem('issues'));

        for (var i = 0; i < issues.length; i++) {
            if (issues[i].id == id) {
                issues.splice(i, 1);
            }
        }
        localStorage.setItem('issues', JSON.stringify(issues));
        fetchIssues();
    }

    function fetchIssues() {
        var issues = JSON.parse(localStorage.getItem('issues'));
        var issuelist = document.getElementById('issuelist');

        issuelist.innerHTML = "";
        for (var i = 0; i < issues.length; i++) {
            var id = issues[i].id;
            var description = issues[i].description;
            var severity = issues[i].severity;
            var assigned = issues[i].assigned;
            var status = issues[i].status;

            issuelist.innerHTML += '<div class="well">' +
                                   '<h6>Issue ID: ' + id + '</h6>' +
                                   '<p><span class="label label-info">' + status + '</span></p>' +
                                   '<h3>' + description + '</h3>' +
                                   '<p><span class="glyphicon glyphicon-time"></span> ' + severity + '</p>' +
                                   '<p><span class="glyphicon glyphicon-user"></span> ' + assigned + '</p>' +
                                   '<a href="#" onclick="setStatusClosed(\'' + id + '\')" class="btn btn-warning">Close</a> ' +
                                   '<a href="#" onclick="deleteIssue(\'' + id + '\')" class="btn btn-danger">Delete</a>' +
                                   '</div>';
        }
    }
}
catch (e) {
    console.log = e.message;
}