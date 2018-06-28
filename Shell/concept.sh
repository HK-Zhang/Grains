#! /bin/bash

# $0 = running script name
# dirname = removes the trailing / component from the NAME and prints the remaining portion. If the NAME does not contain / component then it prints '.' (means current directory)
current_dir="$(dirname $0)"
echo $current_dir


function show_help() {
    cat <<EOF
Usage: ${0##*/} [-h] [-t] [-e ENVIRONMENT] [-n NAMESPACE] [-v VAULT_NAME]
Deploys a Kubernetes Helm chart with in a given environment and namespace.
         -h               display this help and exit
         -e ENVIRONMENT   environment for which the deployment is perfomed (e.g. acs)
         -n NAMESPACE     namespace where the cluster will be deployed
         -r RELEASE_NAME  Helm release name
         -t               validate only the templates without performing any deployment
         -v VAULT_NAME    name of the Aure KeyVault
EOF
}

# Checks the return code of a command
function check_rc() {
    if [ $? -ne 0 ]
    then
        echo $1
        trap on_exit EXIT
        exit -1
    fi
}

# Handler executed on exit
function on_exit() {
    # rm -rf ${cert_folder}
    echo "Clean up"
}

while getopts he:tn:r:v: opt; do
    case $opt in
        h)
            show_help
            exit 0
            ;;
        e)
            echo "ENVIRONMENT is $OPTARG"
            ;;
        t)
            echo "DRY_RUN is true"
            ;;
        n)
            echo "NAMESPACE is $OPTARG"
            ;;
        r)
            echo "RELEASE_NAME is $OPTARG"
            ;;
        v)
            echo "VAULT_NAME is $OPTARG"
            ;;
        *)
            show_help >&2
            exit 1
            ;;
    esac
done

# -np
#    string is not null.
# -z
#   string is null, that is, has zero length
foo="bar"
[ -n "$foo" ] && echo "foo is not null"
[ -z "$foo" ] && echo "foo is null"

foo="";
[ -n "$foo" ] && echo "foo is not null"
[ -z "$foo" ] && echo "foo is null"

#The type command is used to find out if command is builtin or external binary file. It also indicate how it would be interpreted if used as a command name. 
echo "Checking kubectl command"
type kubectl > /dev/null 2>&1
check_rc "kubectl command not found in \$PATH. Please follow the documentation to install it: https://kubernetes.io/docs/tasks/kubectl/install/"
