function file_write() {
    var fs = require('fs');

    var config = {
        maxFiles: 20,
        macConnections: 15,
        rootPath: '/webroot'
    }

    var configTxt = JSON.stringify(config);
    var options = { encoding: 'utf8', flag: 'w' };
    fs.writeFile('config.txt', configTxt, options, function (err) {
        if (err) {
            console.log('Config Write Failed.');
        } else {
            console.log('Config Saved.');
        }
    });
}

function file_write_sync() {
    var fs = require('fs');
    var veggieTray = ['carrots', 'celery', 'olives'];
    fd = fs.openSync('veggie.txt', 'w');
    while (veggieTray.length) {
        veggie = veggieTray.pop() + ' ';
        var bytes = fs.writeSync(fd, veggie, null, null);
        console.log('Wrote %s %dbytes', veggie,bytes);
    }

    fs.closeSync(fd);
}

function file_write_async() {
    var fs = require('fs');
    var fruitBowl = ['apple', 'orange', 'banana', 'grapes'];
    function writeFruit(fd) {
        if (fruitBowl.length) {
            var fruit = fruitBowl.pop() + " ";
            fs.write(fd, fruit, null, null, function (err, bytes) {
                if (err) {
                    console.log('File Write Failed.');
                } else {
                    console.log('Wrote: %s %dbytes', fruit, bytes);
                    writeFruit(fd);
                }
            });
        } else {
            fs.close(fd);
        }
    }

    fs.open('fruit.txt', 'w', function (err, fd) {
        writeFruit(fd);
    });
}

function file_write_stream() {
    var fs = require('fs');

    var grains = ['rice', 'wheat', 'oats'];
    var options = { encoding: 'utf8', flag: 'w' };

    var fileWriteStream = fs.createWriteStream('grains.txt', options);

    fileWriteStream.on('close', function () {
        console.log('File Closed.');
    });

    while (grains.length) {
        var data = grains.pop() + ' ';
        fileWriteStream.write(data);
        console.log('Wrote: %s', data);
    }

    fileWriteStream.end();
}

function file_read() {
    var fs = require('fs');
    var options = { encoding: 'utf8', flag: 'r' };
    fs.readFile('config.txt', options, function (err, data) {
        if (err) {
            console.log('Failed to open Config File.');
        } else {
            console.log('Config Loaded.');
            var config = JSON.parse(data);
            console.log('Max Files: ' + config.maxFiles);
            console.log('Max Connections: ' + config.macConnections);
            console.log('Root path: ' + config.rootPath);
        }
    });
}

function file_read_sync() {
    var fs = require('fs');
    fd = fs.openSync('veggie.txt', 'r');
    var veggies = '';
    do {
        var buf = new Buffer(5);
        buf.fill();
        var bytes = fs.readSync(fd, buf, null, 5);
        console.log('read %dbytes', bytes);
        veggies += buf.toString();
    } while (bytes > 0);
    fs.closeSync(fd);
    console.log('Veggies' + veggies);
}

function file_read_async() {
    var fs = require('fs');
    function readFruit(fd, fruits) {
        var buf = new Buffer(5);
        buf.fill();
        fs.read(fd, buf, 0, 5,null, function (err, bytes, data) {
            if (bytes > 0) {
                console.log('read %dbytes', bytes);
                fruits += data;
                readFruit(fd, fruits);
            } else {
                fs.close(fd);
                console.log('Fruits: %s', fruits);
            }
        });
    }

    fs.open('fruit.txt', 'r', function (err, fd) {
        readFruit(fd, '');
    });
}

function file_read_stream() {
    var fs = require('fs');
    var options = { encoding: 'utf8', flag: 'r' };

    var fileReadStream = fs.createReadStream('grains.txt', options);

    fileReadStream.on('data', function (chunk) {
        console.log('Grains: %s', chunk);
        console.log('Read %d bytes of data.', chunk.length);
    });

    fileReadStream.on('close', function () {
        console.log('File Closed');
    });
}

function file_stats() {
    var fs = require('fs');
    fs.stat('StreamDemo.js', function (err, stats) {
        if (!err) {
            console.log('stats: ' + JSON.stringify(stats, null, ' '));
            console.log(stats.isFile() ? 'Is a File' : 'Is not a File');
            console.log(stats.isDirectory() ? 'Is a Folder' : 'Is not a Folder');
            console.log(stats.isSocket() ? 'Is a Socket' : 'Is not a Socket');
            stats.isDirectory();
            stats.isBlockDevice();
            stats.isCharacterDevice();
            stats.isFIFO();
            stats.isSocket();
        }
    });
}

function file_readdir() {
    var fs = require('fs');
    var Path = require('path');
    function WalkDirs(dirPath) {
        console.log(dirPath);
        fs.readdir(dirPath, function (err, entries) {
            for (var idx in entries) {
                var fullPath = Path.join(dirPath, entries[idx]);
                (function (fullPath) {
                    fs.stat(fullPath, function (err, stats) {
                        if (stats && stats.isFile()) {
                            console.log(fullPath);
                        } else if (stats && stats.isDirectory()) {
                            WalkDirs(fullPath);
                        }
                    });
                })(fullPath);
            }
        });
    }

    WalkDirs('../NodejsConsoleApp1');
}

function main() {
    //file_write();
    //file_write_sync();
    //file_write_async();
    //file_write_stream();
    //file_read();
    //file_read_sync();
    //file_read_async();
    //file_read_stream();
    //file_stats();
    file_readdir();
}

main();