var cluster = require('cluster');
var http = require('http');

if (cluster.isWorker) {
    http.createServer(function (req, res) {
        res.writeHead(200);
        res.end('Process ' + process.pid + ' say hello');
        process.send('Process ' + process.pid + ' handled request');
    }).listen(8080, function () {
        console.log('Child Server Running on Process: ' + process.pid);
    });
};