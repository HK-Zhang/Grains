function os_info() {
    var os = require('os');
    console.log('tmpdir :\t' + os.tmpdir());
    console.log('endianness: \t' + os.endianness());
    console.log('hostname: \t' + os.hostname());
    console.log('type: \t' + os.type());
    console.log('platform: \t' + os.platform());
    console.log('arch: \t' + os.arch());
    console.log('release: \t' + os.release());
    console.log('uptime :\t' + os.uptime());
    console.log('loadavg :\t' + os.loadavg());
    console.log('totalmem :\t' + os.totalmem());
    console.log('freemen :\t' + os.freemem());
    console.log('EOL :\t' + os.EOL);
    console.log('cpus :\t\t' + JSON.stringify(os.cpus()));
    console.log('networkInterfaces : ' + JSON.stringify(os.networkInterfaces()));
}


function util_inherit() {
    var util = require('util');
    var events = require('events');

    function Writer() {
        events.EventEmitter.call(this);
    }

    util.inherits(Writer, events.EventEmitter);

    Writer.prototype.write = function (data) {
        this.emit('data',data);
    };

    var w = new Writer();
    console.log(w instanceof events.EventEmitter);
    console.log(Writer.super_ === events.EventEmitter);

    w.on('data', function (data) {
        console.log('Received data: "'+data+'"');
    });

    w.write('Some Data!');
}

function dns_lookup() {
    var dns = require('dns');
    console.log('Rsolving www.bing.com...');
    dns.resolve4('www.bing.com', function (err, addresses) {
        console.log('IPv4 address: ' + JSON.stringify(addresses, false, ' '));
        addresses.forEach(function (addr) {
            dns.reverse(addr, function (err, domains) {
                console.log('Reverse for ' + addr + ': ' + JSON.stringify(domains));
            });
        });
    });
}

function main() {
    //os_info();
    //util_inherit();
    dns_lookup();
}

main();