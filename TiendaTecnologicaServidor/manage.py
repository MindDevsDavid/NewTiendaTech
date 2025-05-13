#!/usr/bin/env python
#"""Django's command-line utility for administrative tasks."""
#import os
#import sys
#from dotenv import load_dotenv
#load_dotenv(os.path.join(os.path.dirname(file), '.env'))
#from django.core.management import execute_from_command_line


#def main():
#    """Run administrative tasks."""
#    os.environ.setdefault("DJANGO_SETTINGS_MODULE", "tienda_backend.settings")
#    try:
#        from django.core.management import execute_from_command_line
#    except ImportError as exc:
#        raise ImportError(
#            "Couldn't import Django. Are you sure it's installed and "
#           "available on your PYTHONPATH environment variable? Did you "
#            "forget to activate a virtual environment?"
#        ) from exc
#    execute_from_command_line(sys.argv)


#if __name__ == "__main__":
#    main()

import os
import sys

BASE_DIR = os.path.dirname(__file__)

from dotenv import load_dotenv

def main():
    """Run administrative tasks."""
    load_dotenv(os.path.join(BASE_DIR, '.env'))
    os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'tienda_backend.settings')
    try:
        from django.core.management import execute_from_command_line
    except ImportError as exc:
        raise ImportError(
            "Couldn't import Django. Are you sure it's installed and "
            "available on your PYTHONPATH environment variable? Did you "
            "forget to activate a virtual environment?"
        ) from exc
    execute_from_command_line(sys.argv)

if __name__ == "__main__":
    main()