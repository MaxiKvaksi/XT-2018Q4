var currentPage = 0;
var pages = ["page1.html", "page2.html", "page3.html", "page4.html"];
var timer;
var timeToEnd;
const PERIOD_SEC = 5;
function previewPage()
{
    currentPage -= 1;
    if(currentPage == -1)
    {
        currentPage = pages.length - 1;
    }
    goToPage(pages[currentPage]);
}

function nextPage()
{
    currentPage += 1;
    if(currentPage == pages.length)
    {
        if(confirm('Stop site slideshow?(if you press "Cancel" page slideshow will be continue)'))
        {
            stopTimer();
            return;
        }
        currentPage = 0;
    }
    goToPage(pages[currentPage]);
}

function startTimer()
{
    if(currentPage == pages.length && timeToEnd == 0)
    {
        currentPage = 0;
        goToPage(pages[0]);
    }
    timer = setInterval(tick, 1000);
}

function stopTimer()
{
    clearTimeout(timer);
}

function ShowNextByTimeout()
{
    var params = window.location.href.split("?")[1];
    if(params != null)
    {
        currentPage = +(params.split("=")[1]);
    }
    else
    {
        goToPage(pages[0]);
    }
    timeToEnd = PERIOD_SEC;
    startTimer();
}

function tick()
{
    timeToEnd -= 1;
    if(timeToEnd == 0)
    {
        nextPage();
    }
    document.getElementById('timer').innerHTML = timeToEnd;
}

function goToPage(page)
{
    document.location.href = page + "?previewPage=" + currentPage;
}