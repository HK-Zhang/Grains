function process_info() {
    var util = require('util');
    console.log('Current directory: ' + process.cwd());
    console.log('Environment Settings: ' + JSON.stringify(process.env));
    console.log('Node Args: ' + process.argv);
    console.log('Execution Path: ' + process.execPath);
    console.log('Execution Args: ' + JSON.stringify(process.execArgv));
    console.log('Node Versions: ' + process.version);
    console.log('Module Vereions: ' + JSON.stringify(process.versions));
    console.log('Process ID: ' + process.pid);
    console.log('Process Title: ' + process.title);
    console.log('Process Platform: ' + process.platform);
    console.log('Process Architecture: ' + process.arch);
    console.log('Memory Usage: ' + util.inspect(process.memoryUsage()));
    var start = process.hrtime();

    setTimeout(function () {
        var delta = process.hrtime(start);
        console.log('High-Res timer took %d seconds and %d nanoseconds', delta[0], delta[1]);
        console.log('Node has been running %d seconds', process.uptime());
    },1000);
}

function child_exec() {
    var childProcess = require('child_process');
    var options = { maxBuffers: 100 * 1024, encoding: 'utf8', timeout: 5000 };
    var child = childProcess.exec('dir /B', options, function (error, stdout, stderr) {
        if (error) {
            console.log(error.stack);
            console.log('Error Code: ' + error.code);
            console.log('Error Signal: ' + error.signal);
        }

        console.log('Results: \n' + stdout);

        if (stderr.length) {
            console.log('Errors: ' + stderr)
        }
    });

    child.on('exit', function (code) {
        console.log('Completed with code: ' + code);
    });
}

function child_process_exec_file() {
    var childProcess = require('child_process');
    var options = { maxBuffers: 100 * 1024, encoding: 'utf8', timeout: 5000 };
    var child = childProcess.execFile('ping.exe', ['-n', '1', 'bing.com'], options, function (error, stdout, stderr) {
        if (error) {
            console.log(error.stack);
            console.log('Error Code: ' + error.code);
            console.log('Error Signal: ' + error.signal);
        }

        console.log('Results: \n' + stdout);

        if (stderr.length) {
            console.log('Errors: ' + stderr)
        }
    });


    child.on('exit', function (code) {
        console.log('Completed with code: ' + code);
    });
}

function child_process_spawn_file() {
    var spawn = require('child_process').spawn;
    var options = {
        env: { user: 'brad' },
        detached: false,
        stdio:['pipe','pipe','pipe']
    }

    var child = spawn('netstat', ['-e']);

    child.stdout.on('data', function (data) {
        console.log(data.toString());
    });

    child.stderr.on('data', function (data) {
        console.log(data.toString());
    });


    child.on('exit', function (code) {
        console.log('Child exited with code', code);
    });
}

function child_fork() {
    var child_process = require('child_process');

    var options = {
        env: { user: 'Brad' },
        encoding:'utf8'
    };

    function makeChild() {
        var child = child_process.fork('chef.js', [], options);

        child.on('message', function (message) {
            console.log('Served: ' + message);
        });

        return child;
    }

    function sendCommand(child, command) {
        console.log('Requesting: ' + command);
        child.send({ cmd: command });
    }

    var child1 = makeChild();
    var child2 = makeChild();
    var child3 = makeChild();

    sendCommand(child1, 'makeBreakfast');
    sendCommand(child2, 'makeLunch');
    sendCommand(child3, 'makeDinner');
}


function cluster_server() {
    var cluster = require('cluster');
    var http = require('http');

    if (cluster.isMaster) {
        cluster.on('fork', function (worker) {
            console.log('Worker ' + worker.id + " created");
        });

        cluster.on('listening', function (worker, address) {
            console.log('Worker ' + worker.id + ' is listening on ' +
                address.address + ':' + address.port);
        });

        cluster.on('exit', function (worker, code, signal) {
            console.log('Worker ' + worker.id + ' Exited');
        });


        cluster.setupMaster({ exec: 'cluster_worker.js' });

        var numCPUs = require('os').cpus().length;

        for (var i = 0; i < numCPUs; i++) {
            if (i >= 4) break;
            cluster.fork();
        }

        Object.keys(cluster.workers).forEach(function (id) {
            cluster.workers[id].on('message', function (message) {
                console.log(message);
            });
        });
    }
}

function cluster_client() {
    var http = require('http');
    var options = { port: '8080' };

    function sendRequest() {
        http.request(options, function (response) {
            var serverData = '';
            response.on('data', function (chunk) {
                serverData += chunk;
            });
            response.on('end', function () {
                console.log(serverData);
            });
        }).end();
    }

    for (var i = 0; i < 5; i++){
        console.log('Sending Request');
        sendRequest();
    }
}

function main() {
    //process_info();
    //child_exec();
    //child_process_exec_file();
    //child_process_spawn_file();
    //child_fork();
    cluster_server();
    cluster_client();
}

main();